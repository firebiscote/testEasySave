using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.HistoryLog;
using testEasySave.Model.Data.Log.HistoryLog.HistoryBuilder;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public class HistoryLogService : ILogService
    {
        private FileInfo historyLogFile;

        public HistoryLogService()
        {
            SetHistoryLogFile();
        }

        private void SetHistoryLogFile()
        {
            SetHistoryLogDirectory();
            string historyLogName = Parameters.HistoryLogNameStart + DateTime.Today.ToString(Parameters.HistoryLogDateFormat).Replace(Parameters.HistoryLogDateSeparator, Parameters.HistoryLogNameSeparator);
            historyLogFile = new FileInfo(Parameters.HistoryLogDirectory + historyLogName + Parameters.FileType);
            if (!historyLogFile.Exists)
                historyLogFile.Create().Close();
        }

        private void SetHistoryLogDirectory()
        {
            new DirectoryInfo(Parameters.HistoryLogDirectory).Create();
        }

        public void Handle(object sender, CopyFileEventArgs args)
        {
            SetHistoryLogFile();
            string json = GetHistoryLogFileJson();
            List<IHistoryLog> historyLogs = DeserializeHistoryLogs(json);
            historyLogs.Add(HistoryLogDirector.Instance.GetNewHistoryLog((IBackupJob)sender, args.File, args.Start));
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
                logs.AddRange(JsonSerializer.Deserialize<List<HistoryLog>>(json));
            }
            catch (Exception) { }
            return logs;
        }

        private string SerializeHistoryLogs(List<IHistoryLog> logs)
        {
            return JsonSerializer.Serialize(logs, Parameters.SerializerOptions);
        }
    }
}
