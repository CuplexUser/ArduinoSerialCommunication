namespace SerialMonitor.EventStatus
{
	public static class SerialEventHandlers
	{
		public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventHandlerArgs args);
		public delegate void SerialConnectionUpdateStateEventHandler(object sender, SerialConnectionStateEventArgs args);
	}
}