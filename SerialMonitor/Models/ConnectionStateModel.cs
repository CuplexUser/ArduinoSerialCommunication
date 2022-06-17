namespace SerialMonitor.Models
{
	/// <summary>
	/// ConnectionStateModel
	/// </summary>
	public class ConnectionStateModel
	{
		public static readonly ConnectionStateModel NoConnectionInfoState = new ConnectionStateModel { BaudRate = "", ComPort = "", IsConnected = false, NoInfoAvailable = true };

		/// <summary>
		/// Gets or sets a value indicating whether this instance is connected.
		/// </summary>
		/// <value>
		///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
		/// </value>
		public bool IsConnected { get; set; }
		/// <summary>
		/// Gets or sets the COM port.
		/// </summary>
		/// <value>
		/// The COM port.
		/// </value>
		public string ComPort { get; set; }
		/// <summary>
		/// Gets or sets the baud rate.
		/// </summary>
		/// <value>
		/// The baud rate.
		/// </value>
		public string BaudRate { get; set; }

		/// <summary>
		/// Gets a value indicating whether [no information available].
		/// </summary>
		/// <value>
		///   <c>true</c> if [no information available]; otherwise, <c>false</c>.
		/// </value>
		public bool NoInfoAvailable { get; private init; }

		/// <summary>
		/// Gets the no connection information.
		/// </summary>
		/// <value>
		/// The no connection information.
		/// </value>
		public static ConnectionStateModel NoConnectionInfo => NoConnectionInfoState;
	}
}