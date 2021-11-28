using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.StateLog;
using testEasySave.Model.Data.Log.StateLog.StateBuilder;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public class StateLogService : IService
    {
        public static StateLogService Instance = new StateLogService();
        private FileInfo stateLogFile;

        private StateLogService()
        {
            SetStateLogFile();
            FullSaveJob.FileCopied += HandleState;
            DifferentialSaveJob.FileCopied += HandleState;
        }

        private void SetStateLogFile()
        {
            stateLogFile = new FileInfo(Parameters.StateLogFile + Parameters.FileType);
            if (!stateLogFile.Exists)
                stateLogFile.Create().Close();
        }

        private void HandleState(object sender, CopyFileEventArgs args)
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
            return JsonConvert.SerializeObject(logs, Formatting.Indented);
        }
    }
}
