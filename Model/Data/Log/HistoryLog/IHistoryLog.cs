namespace EasySave.Model.Data.Log.HistoryLog
{
    public interface IHistoryLog
    {
        public string SaveJobName { get; set; }
        public string Timestamp { get; set; }
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public long FileSize { get; set; }
        public double CopyDuration { get; set; }
    }
}
