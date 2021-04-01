namespace SerialMonitor.EventStatus
{
    public static class EventDelegates
    {
        public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventHandlerArgs args);

        public delegate void SerialConnectionStateEventHandler(object sender, SerialConStatusChangedEventArgs args);
    }
}