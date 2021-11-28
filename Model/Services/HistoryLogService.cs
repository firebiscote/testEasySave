using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            SetHistoryLogFile();
            string json = GetHistoryLogFileJson();
            List<IHistoryLog> historyLogs = DeserializeHistoryLogs(json);
            historyLogs.Add(HistoryLogDirector.Instance.GetNewHistoryLog((ISaveJob)sender, args.File, args.Start));
            json = SerializeHistoryLogs(historyLogs);
            WriteTextToHistoryLogFile(json);
        }

        private string GetHistoryLogFileJson()
        {
            string fileName = Directory.GetFiles(Parameters.HistoryLogDirectory, Parameters.FilePattern)[^1];
            return File.ReadAllText(fileName);
        }

        private void WriteTextToHistoryLogFile(string json)
        {
            SetHistoryLogFile();
            historyLogFile.Delete();
            using StreamWriter sw = historyLogFile.CreateText();
            sw.Write(json);
        }

        private List<IHistoryLog> DeserializeHistoryLogs(string json)
        {
            List<IHistoryLog> logs = new List<IHistoryLog>();
            try
            {
                logs.AddRange(JsonConvert.DeserializeObject<List<HistoryLog>>(json));
            }
            catch (JsonReaderException) { }
            return logs;
        }

        private string SerializeHistoryLogs(List<IHistoryLog> logs)
        {
            return JsonConvert.SerializeObject(logs, Formatting.Indented);
        }
    }
}
