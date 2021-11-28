using System;
using System.Collections.Generic;
using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.SaveJob.SaveJobFactory;
using testEasySave.Model.Services;

namespace testEasySave.Model
{
    public class MainModel : IModel
    {
        private readonly SaveJobService saveJobService;
        private Dictionary<string, string> args;
        private Dictionary<string, Action> actions;

        public MainModel()
        {
            saveJobService = new SaveJobService();
            _ = HistoryLogService.Instance;
            InitActions();
        }

        private void InitActions()
        {
            actions = new Dictionary<string, Action>
            {
                { Parameters.Show, Show },
                { Parameters.Create, Create },
                { Parameters.Delete, Delete },
                { Parameters.Execute, Execute },
                { Parameters.Language, SetLang },
                { Parameters.SetLogDirectory, SetLogPath },
                { Parameters.Help, Help },
                { Parameters.Quit, Quit },
            };
        }

        public void Process(string action, Dictionary<string, string> arguments)
        {
            if (!actions.ContainsKey(action))
                throw new CommandNotExistException(action);
            args = arguments;
            actions[action].Invoke();
        }

        private void Show()
        {
            string saveJobsList = "";
            foreach (ISaveJob saveJob in saveJobService.saveJobs.Values)
                saveJobsList += Parameters.SaveJobStart + saveJob.Name + Parameters.SaveJobSeparator + saveJob.SourceDirectory + Parameters.DirectorySeparator + saveJob.TargetDirectory + Parameters.TypeSeparator + saveJob.Type + "\n";
            throw new ShowException(saveJobsList);
        }

        private void Create()
        {
            ISaveJob newSaveJob = SaveJobFactory.Instance.GetNewSaveJob(args[Parameters.Name], args[Parameters.SourceDirectory], args[Parameters.TargetDirectory], args[Parameters.Type]);
            saveJobService.Create(newSaveJob);
        }

        private void Delete()
        {
            if (args.Count == 0)
                saveJobService.DeleteAll();
            else
                saveJobService.Delete(args[Parameters.Name]);
        }

        private void Execute()
        {
            if (args.Count == 0)
                saveJobService.ExecuteAll();
            else
                saveJobService.Execute(args[Parameters.Name]);
        }

        private void SetLang()
        {
            TraductionService.Instance.SetLanguage(args[Parameters.Lang]);
        }

        private void SetLogPath()
        {
            throw new NotImplementedException();
        }

        private void Help()
        {
            throw new HelpException(Parameters.HelpMessage);
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
