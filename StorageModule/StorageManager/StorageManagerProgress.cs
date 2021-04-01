namespace StorageModule.StorageManager
{
    public class StorageManagerProgress
    {
        private int _progressPercentage;

        public int ProgressPercentage
        {
            get => _progressPercentage;
            set
            {
                if (value >= 0 && value <= 100)
                    _progressPercentage = value;
            }
        }

        public string Text { get; set; }
    }
}