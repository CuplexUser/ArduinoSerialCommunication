using SerialMonitor.EventStatus;
using SerialMonitor.Service;

namespace SerialMonitor.Delegates
{
    public static class EventDelegates
    {
        public delegate void SerialDataReceivedEventHandler(object sender, SerialDataReceivedEventHandlerArgs args);

        public delegate void SerialConnectionStateEventHandler(object sender, SerialConStatusChangedEventArgs args);
    }
}