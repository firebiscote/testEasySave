using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using EasySave.Model.Data.Job;
using EasySave.Model.Data.Log.StateLog;
using EasySave.Model.Data.Log.StateLog.StateBuilder;
using EasySave.Model.Data.ToolBox;

namespace EasySave.Model.Services
{
    public class StateLogService : ILogService
    {
        private FileInfo stateLogFile;

        public StateLogService()
        {
            SetStateLogFile();
        }

        private void SetStateLogFile()
        {
            SetStateLogDirectory();
            stateLogFile = new FileInfo(Parameters.StateLogFile);
            if (!stateLogFile.Exists)
                stateLogFile.Create().Close();
        }

        private void SetStateLogDirectory()
        {
            new DirectoryInfo(Parameters.StateLogDirectory).Create();
        }

        public void Handle(object sender, CopyFileEventArgs args)
        {
            List<IStateLog> stateLogs = new List<IStateLog>();
            foreach (IBackupJob saveJob in BackupJobService.Instance.BackupJobs.Values)
            {
                if (((IBackupJob)sender).Name == saveJob.Name)
                    stateLogs.Add(StateLogDirector.Instance.GetNewActiveStateLog(saveJob, args.File, args.RemainingFiles));
                else
                    stateLogs.Add(StateLogDirector.Instance.GetNewEndStateLog(saveJob));
            }
            string json = SerializeStateLogs(stateLogs);
            WriteTextToStateLogFile(json);
        }

        private void WriteTextToStateLogFile(string json)
        {
            stateLogFile.Delete();
            using StreamWriter sw = stateLogFile.CreateText();
            sw.Write(json);
        }

        private string SerializeStateLogs(List<IStateLog> logs)
        {
            return JsonSerializer.Serialize(logs, Parameters.SerializerOptions);
        }
    }
}
