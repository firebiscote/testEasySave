namespace testEasySave.Model.Data.Log.HistoryLog
{
    public class HistoryLog : IHistoryLog
    {
        public string SaveJobName { get; set; }
        public string Timestamp { get; set; }
        public string SourceFileName { get; set; }
        public string TargetFileName { get; set; }
        public long FileSize { get; set; }
        public double CopyDuration { get; set; }

        public HistoryLog() { }
    }
}
