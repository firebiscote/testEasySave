using System;
using System.IO;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log;
using testEasySave.Model.Data.Log.LogFactory;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public class LogService
    {
        private FileInfo historyLogFile;
        private DateTime copyStart;

        public LogService()
        {
            SetHistoryLogFile();
            FullSaveJob.StartCopy += SetStartTime;
            DifferentialSaveJob.StartCopy += SetStartTime;
            FullSaveJob.FileCopied += HandleHistory;
            DifferentialSaveJob.FileCopied += HandleHistory;
        }

        private void SetHistoryLogFile()
        {
            string historyLogName = Parameters.HistoryLogName + DateTime.Today.ToString("dd/MM/yy").Replace("/", "");
            historyLogFile = new FileInfo(Parameters.HistoryLogDirectory + historyLogName + Parameters.FileType);
            if (!historyLogFile.Exists)
                historyLogFile.Create();
        }

        private void SetStartTime(object sender, EventArgs args)
        {
            copyStart = DateTime.Now;
        }

        private void HandleHistory(object sender, FileEventArgs args)
        {
            HistoryLog log = LogFactory.Instance.GetNewHistoryLog((ISaveJob)sender, args.File, DateTime.Now - copyStart);
            string jsonLog = SerializeLog(log);
            AppendTextToHistoryLog(jsonLog);
        }

        private void AppendTextToHistoryLog(string text)
        {
            if (historyLogFile.Name != DateTime.Today.ToString())
                SetHistoryLogFile();
            using StreamWriter sw = historyLogFile.AppendText();
            sw.WriteLine(text);
        }

        private string SerializeLog(ILog log)
        {
            return JsonSerializer.Serialize(log);
        }
    }
}
