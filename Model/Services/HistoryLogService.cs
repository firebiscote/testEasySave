using System;
using System.IO;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.HistoryLog;
using testEasySave.Model.Data.Log.HistoryLog.HistoryBuilder;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public class HistoryLogService : IService
    {
        public static HistoryLogService Instance = new HistoryLogService();
        private FileInfo historyLogFile;

        private HistoryLogService()
        {
            SetHistoryLogFile();
            FullSaveJob.FileCopied += HandleHistory;
            DifferentialSaveJob.FileCopied += HandleHistory;
        }

        private void SetHistoryLogFile()
        {
            string historyLogName = Parameters.HistoryLogNameStart + DateTime.Today.ToString(Parameters.HistoryLogDateFormat).Replace(Parameters.HistoryLogDateSeparator, Parameters.HistoryLogNameSeparator);
            historyLogFile = new FileInfo(Parameters.HistoryLogDirectory + historyLogName + Parameters.FileType);
            if (!historyLogFile.Exists)
                historyLogFile.Create().Close();
        }

        private void HandleHistory(object sender, CopyFileEventArgs args)
        {
            IHistoryLog log = HistoryLogDirector.Instance.GetNewHistoryLog((ISaveJob)sender, args.File, args.Start);
            string jsonLog = SerializeHistoryLog(log);
            AppendTextToHistoryLog(jsonLog);
        }

        private void AppendTextToHistoryLog(string text)
        {
            if (historyLogFile.Name != DateTime.Today.ToString())
                SetHistoryLogFile();
            using StreamWriter sw = historyLogFile.AppendText();
            sw.WriteLine(text);
        }

        private string SerializeHistoryLog(IHistoryLog log)
        {
            return JsonSerializer.Serialize(log);
        }
    }
}
