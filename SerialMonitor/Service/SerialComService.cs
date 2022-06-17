using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SerialMonitor.EventStatus;
using SerialMonitor.Models;
using Serilog;
using StorageModule.Models.Enums;

namespace SerialMonitor.Service
{
    /// <summary>
    ///     Serial Data communication Service
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="SerialMonitor.Service.ServiceBase" />
    public class SerialComService : ServiceBase, IDisposable
    {
        /// <summary>
        ///     The baud rates
        /// </summary>
        private readonly int[] _baudRates = { 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };

        /// <summary>
        ///     The serial COM wait handle
        /// </summary>
        private AutoResetEvent _serialComWaitHandle;

        private readonly ILogger _logger;

        /// <summary>
        ///     The is reading serial data
        /// </summary>
        private bool _isReadingSerialData;

        /// <summary>
        ///     The read task
        /// </summary>
        private Task _readTask;

        /// <summary>
        ///     The serial COM thread active
        /// </summary>
        private bool _serialComThreadActive;

        /// <summary>
        ///     The serial port
        /// </summary>
        private SerialPort _serialPort;

        /// <summary>
        ///     Prevents a default instance of the <see cref="SerialComService" /> class from being created.
        /// </summary>
        public SerialComService(ILogger logger)
        {
            _logger = logger;
            _serialComWaitHandle = new AutoResetEvent(false);
            _serialComThreadActive = true;
            _isReadingSerialData = false;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is reading serial data.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is reading serial data; otherwise, <c>false</c>.
        /// </value>
        private bool IsReadingSerialData
        {
            get => _readTask?.Status == TaskStatus.Running && _isReadingSerialData;

            set
            {
                //if (value && _cancellationToken.IsCancellationRequested) throw new InvalidOperationException("Unable to create new SerialDataReaderTask when cancellation is requested");

                if (_isReadingSerialData && !value && _readTask != null)
                {
                    //_readTask.
                }


                _isReadingSerialData = value;
            }
        }

        /// <summary>
        ///     Gets the last error.
        /// </summary>
        /// <value>
        ///     The last error.
        /// </value>
        public string LastError { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is connected.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected => _serialPort != null && _serialPort.IsOpen;

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _serialComThreadActive = false;
            if (_serialComWaitHandle != null)
            {
                _serialComWaitHandle.Close();
                _serialComWaitHandle.Dispose();
                _serialComWaitHandle = null;
            }

            _serialPort?.Dispose();
        }


        /// <summary>
        ///     Occurs when [serial connection state changed].
        /// </summary>
        public event SerialEventHandlers.SerialConnectionUpdateStateEventHandler SerialConnectionStateChanged;

        /// <summary>
        ///     Occurs when [serial data received].
        /// </summary>
        public event SerialEventHandlers.SerialDataReceivedEventHandler SerialDataReceived;


        /// <summary>
        ///     Starts the serial read task.
        /// </summary>
        private void StartSerialReadTask()
        {
            if (!IsReadingSerialData)
                try
                {
                    _readTask = GetDataReaderTask();

                    //var awaiter = _readTask.GetAwaiter();
                    //awaiter.OnCompleted(() => IsReadingSerialData = false);

                    _serialComWaitHandle.Set();
                    _readTask.Start();
                }

                catch (Exception exception)
                {
                    IsReadingSerialData = false;
                    LastError = exception.Message;
                    _serialComWaitHandle.Reset();
                    SerialConnectionStateChanged?.Invoke(this, new SerialConnectionStateEventArgs(ConnectionStatus.Error, exception.Message));
                }
        }

        /// <summary>
        ///     Gets the data reader task.
        /// </summary>
        /// <returns></returns>
        private Task GetDataReaderTask()
        {
            var dataReadTask = new Task(ReadSerialDataAndInvokeDataReadEvent);
            return dataReadTask;
        }


        /// <summary>
        ///     Reads the serial data and invoke data read event.
        /// </summary>
        private void ReadSerialDataAndInvokeDataReadEvent()
        {
            var sb = new StringBuilder();

            while (_serialComThreadActive)
            {
                IsReadingSerialData = true;

                do
                {
                    while (_serialPort.BytesToRead > 0) sb.Append(_serialPort.ReadLine());


                    if (sb.Length > 0)
                    {
                        SerialDataReceived?.Invoke(this, new SerialDataReceivedEventHandlerArgs(sb.ToString()));
                        sb.Clear();
                    }

                    _readTask.Wait(TimeSpan.FromMilliseconds(200));
                } while (_serialPort.BytesToRead > 0);


                IsReadingSerialData = false;
                _serialComWaitHandle.WaitOne();
            }
        }


        /// <summary>
        ///     Connects the specified port name.
        /// </summary>
        /// <param name="portName">Name of the port.</param>
        /// <param name="baudRate">The selected baud rate.</param>
        /// <returns></returns>
        public bool Connect(string portName, int baudRate)
        {
            try
            {
                _serialPort = new SerialPort(portName, baudRate);

                //Default Value is 4 kb
                _serialPort.ReadBufferSize = 32768;

                _serialPort.Open();
                _serialPort.DataReceived += OnSerialPort_DataReceived;
                _serialPort.PinChanged += OnSerialPort_PinChanged;
                _serialPort.ErrorReceived += OnSerialPort_ErrorReceived;

                StartSerialReadTask();
                SerialConnectionStateChanged?.Invoke(this, new SerialConnectionStateEventArgs(_serialPort.IsOpen ? ConnectionStatus.Connected : ConnectionStatus.Disconnected));
            }
            catch (Exception exception)
            {
                SerialConnectionStateChanged?.Invoke(this, new SerialConnectionStateEventArgs(ConnectionStatus.Error, exception.Message));
                LastError = exception.Message;
                _logger.Error(exception, "Connection exception using {portName}, {Baudrate}", portName, baudRate.ToString());
                return false;
            }

            _logger.Information("Connected successfully to {portName}, at {baudRate}", portName, baudRate);
            return true;
        }

        public static string[] GetPortNamesAvailable()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        ///     Called when [serial port error received].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SerialErrorReceivedEventArgs" /> instance containing the event data.</param>
        private void OnSerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialConnectionStateChanged?.Invoke(this, new SerialConnectionStateEventArgs(ConnectionStatus.Error, e.EventType.ToString()));
        }


        /// <summary>
        ///     Called when [serial port pin changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SerialPinChangedEventArgs" /> instance containing the event data.</param>
        private void OnSerialPort_PinChanged(object sender, SerialPinChangedEventArgs e)
        {
            // Thread wakeup event
            _serialComWaitHandle.Set();
        }

        /// <summary>
        ///     Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {
            if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                {
                    //_logger.Information("Disconnected from serialport {port}", _serialPort.PortName);
                    _serialPort.Close();
                    SerialConnectionStateChanged?.Invoke(this, new SerialConnectionStateEventArgs(ConnectionStatus.Disconnected));
                }

                _serialPort.DataReceived -= OnSerialPort_DataReceived;
                _serialPort.ErrorReceived -= OnSerialPort_ErrorReceived;
                _serialPort.Dispose();
                _serialPort = null;
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Called when data is received and will read the device data async and trigger its own Data received event when
        ///     either the receive buffer is full or all data has been read.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SerialDataReceivedEventArgs" /> instance containing the event data.</param>
        private void OnSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _serialComWaitHandle.Set();
            if (e.EventType == SerialData.Eof) Debug.WriteLine("SerialData.Eof event");
        }

        /// <summary>
        ///     Gets the baud rates.
        /// </summary>
        /// <returns></returns>
        public string[] GetBaudRates()
        {
            return _baudRates.Select(x => x.ToString()).ToArray();
        }

        public bool SendTextLine(string text)
        {
            if (IsConnected)
            {
                _serialPort.WriteLine(text);
                return true;
            }

            return false;
        }

        public ConnectionStateModel GetConnectionStatus()
        {
            if (_serialPort!=null)
                return new ConnectionStateModel {BaudRate = _serialPort.BaudRate.ToString(), ComPort = _serialPort.PortName, IsConnected = _serialPort.IsOpen};
            return ConnectionStateModel.NoConnectionInfo;
        }
    }
}