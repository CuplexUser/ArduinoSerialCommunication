namespace SerialMonitor.Models
{
    public class AsyncOperationResult
    {
        public bool Successful { get; set; }
        public bool TimedOut { get; set; }

        public string ErrorMessage { get; set; }

        public AsyncOperationResult(bool successful, bool timedOut, string errorMessage="")
        {
            Successful = successful;
            TimedOut = timedOut;
            ErrorMessage = errorMessage;
        }
    }
}