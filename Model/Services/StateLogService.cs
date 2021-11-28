using System.IO;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.Log.StateLog;
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
            stateLogFile = new FileInfo(Parameters.StateLogFile);
            if (!stateLogFile.Exists)
                stateLogFile.Create().Close();
        }

        private void HandleState(object sender, CopyFileEventArgs args)
        {
            string jsonLog = "";
            foreach (ISaveJob saveJob in lol)
            {
                IStateLog log = StateLogDirector.Instance.GetNewHistoryLog((ISaveJob)sender, args.File, args.Start);
                jsonLog += SerializeStateLog(log) + "\n";
            }
            WriteTextToStateLog(jsonLog);
        }

        private void WriteTextToStateLog(string text)
        {
            stateLogFile.Delete();
            using StreamWriter sw = stateLogFile.CreateText();
            sw.WriteLine(text);
        }

        private string SerializeStateLog(IStateLog log)
        {
            return JsonSerializer.Serialize(log);
        }
    }
}
