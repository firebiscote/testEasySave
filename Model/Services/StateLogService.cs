using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.StateLog;
using testEasySave.Model.Data.Log.StateLog.StateBuilder;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
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
            stateLogFile = new FileInfo(Parameters.StateLogFile + Parameters.FileType);
            if (!stateLogFile.Exists)
                stateLogFile.Create().Close();
        }

        public void Handle(object sender, CopyFileEventArgs args)
        {
            List<IStateLog> stateLogs = new List<IStateLog>();
            foreach (ISaveJob saveJob in SaveJobService.Instance.SaveJobs.Values)
            {
                if (((ISaveJob)sender).Name == saveJob.Name)
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
            return JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
