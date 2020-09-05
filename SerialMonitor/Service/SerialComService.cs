using System;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SerialMonitor.Service
{
    /// <summary>
    ///     Serial Data communication Service
    /// </summary>
    /// <seealso cref="SerialMonitor.Service.ServiceBase" />
    public class SerialComService : ServiceBase, IDisposable
    {
        /// <summary>
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SerialConnectionFailedEventArgs" /> instance containing the event data.</param>
        public delegate void SerialConnectionFailedEventHandler(object sender, SerialConnectionFailedEventArgs e);

        /// <summary>
        ///     The baud rates
        /// </summary>
        private readonly int[] _baudRates = {9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000};

        private CancellationToken _cancellationToken;

        private bool _isReadingSerialData;

        private Task _readTask;

        /// <summary>
        ///     The serial port
        /// </summary>
        private SerialPort _serialPort;

        /// <summary>
        ///     Prevents a default instance of the <see cref="SerialComService" /> class from being created.
        /// </summary>
        private SerialComService()
        {
            SerialConnectionError += OnSerialComService_SerialConnectionError;
            _cancellationToken = new CancellationToken(false);
            _isReadingSerialData = false;
        }

        private bool IsReadingSerialData
        {
            get => _isReadingSerialData;

            set
            {
                //if (value && _cancellationToken.IsCancellationRequested) throw new InvalidOperationException("Unable to create new SerialDataReaderTask when cancellation is requested");

                if (_isReadingSerialData && !value && _readTask!=null)
                {
                    //_readTask.
                }


                _isReadingSerialData = value;
            }
        }

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static SerialComService Instance { get; } = new SerialComService();

        /// <summary>
        ///     Gets the last error.
        /// </summary>
        /// <value>
        ///     The last error.
        /// </value>
        public string LastError { get; private set; }

        /// <summary>
        ///     Occurs when [serial connection error].
        /// </summary>
        public event SerialConnectionFailedEventHandler SerialConnectionError;

        /// <summary>
        ///     Occurs when [serial data received].
        /// </summary>
        public event SerialDataReceivedEventHandler SerialDataReceived;

        /// <summary>
        ///     Called when [serial COM service serial connection error].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SerialConnectionFailedEventArgs" /> instance containing the event data.</param>
        private void OnSerialComService_SerialConnectionError(object sender, SerialConnectionFailedEventArgs e)
        {
            LastError = e.ErrorMessage;
        }

        private void ReadDataAsync()
        {
            if (!IsReadingSerialData)
                try
                {
                    IsReadingSerialData = true;

                    _readTask = GetDataReaderTask(_cancellationToken);

                    //var awaiter = _readTask.GetAwaiter();
                    //awaiter.OnCompleted(() => IsReadingSerialData = false);


                    _readTask.Start();
                }
                catch (Exception exception)
                {
                    IsReadingSerialData = false;
                }

            //_readTask.ConfigureAwait(true);
        }

        private Task GetDataReaderTask(CancellationToken cancellationToken)
        {
            var dataReadTask = new Task(ReadSerialDataAndInvokeDataReadEvent, cancellationToken);
            return dataReadTask;
        }


        private void ReadSerialDataAndInvokeDataReadEvent()
        {
            while (_serialPort.BytesToRead > 0)
            {
                string serialData = _serialPort.ReadExisting();

                SerialDataReceived?.Invoke(this, new SerialDataReceivedEventHandlerArgs(serialData));
            }

            IsReadingSerialData = false;
        }


        /// <summary>
        ///     Connects the specified port name.
        /// </summary>
        /// <param name="portName">Name of the port.</param>
        /// <param name="selectedBaudRate">The selected baud rate.</param>
        /// <returns></returns>
        public bool Connect(string portName, string selectedBaudRate)
        {
            try
            {
                int baudRate = Convert.ToInt32(selectedBaudRate);
                _serialPort = new SerialPort(portName, baudRate);

                _serialPort.Open();
                _serialPort.DataReceived += OnSerialPort_DataReceived;
            }
            catch (Exception exception)
            {
                SerialConnectionError?.Invoke(this, new SerialConnectionFailedEventArgs(exception.Message));
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Disconnects this instance.
        /// </summary>
        /// <returns></returns>
        public bool Disconnect()
        {

            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.DataReceived -= OnSerialPort_DataReceived;
                _serialPort.Dispose();
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
            if (e.EventType == SerialData.Chars) ReadDataAsync();
        }

        /// <summary>
        ///     Gets the baud rates.
        /// </summary>
        /// <returns></returns>
        public string[] GetBaudRates()
        {
            return _baudRates.Select(x => x.ToString()).ToArray();
        }

        public void Dispose()
        {
            _readTask?.Dispose();
            _serialPort?.Dispose();
        }
    }


    /// <summary>
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The arguments.</param>
    public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventHandlerArgs args);

    /// <summary>
    /// </summary>
    public class SerialDataReceivedEventHandlerArgs : EventArgs
    {
        public SerialDataReceivedEventHandlerArgs(string serialDataReceived)
        {
            DataReceived = serialDataReceived;
        }

        public string DataReceived { get; private set; }
    }

    /// <summary>
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SerialConnectionFailedEventArgs : EventArgs
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SerialConnectionFailedEventArgs" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public SerialConnectionFailedEventArgs(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }


        /// <summary>
        ///     Gets the error message.
        /// </summary>
        /// <value>
        ///     The error message.
        /// </value>
        public string ErrorMessage { get; }
    }
}