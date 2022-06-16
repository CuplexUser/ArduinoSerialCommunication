using System;

namespace SerialMonitor.EventStatus
{
    /// <summary>
    /// SerialDataReceivedEventHandlerArgs
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class SerialDataReceivedEventHandlerArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SerialDataReceivedEventHandlerArgs"/> class.
        /// </summary>
        /// <param name="serialDataReceived">The serial data received.</param>
        public SerialDataReceivedEventHandlerArgs(string serialDataReceived)
        {
            DataReceived = serialDataReceived;
        }

        /// <summary>
        /// Gets the data received.
        /// </summary>
        /// <value>
        /// The data received.
        /// </value>
        public string DataReceived { get; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return !string.IsNullOrEmpty(DataReceived) ? DataReceived : base.ToString();
        }
    }
}