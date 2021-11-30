using System;
using System.Collections.Generic;
using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.BackupJob.BackupJobBuilder;
using testEasySave.Model.Services;

namespace testEasySave.Model
{
    public class MainModel : IModel
    {
        private Dictionary<string, string> args;
        private Dictionary<string, Action> actions;

        public MainModel()
        {
            _ = BackupJobService.Instance;
            _ = GlobalLogService.Instance;
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
            string saveJobsList = "\n";
            foreach (IBackupJob saveJob in BackupJobService.Instance.BackupJobs.Values)
                saveJobsList += Parameters.BackupJobStart + saveJob.Name + Parameters.BackupJobSeparator + saveJob.SourceDirectory + Parameters.DirectorySeparator + saveJob.TargetDirectory + Parameters.TypeSeparator + saveJob.Type + "\n";
            throw new ShowException(saveJobsList);
        }

        private void Create()
        {
            IBackupJob newSaveJob = BackupJobDirector.Instance.GetNewSaveJob(args[Parameters.Name], args[Parameters.SourceDirectory], args[Parameters.TargetDirectory], args[Parameters.Type]);
            BackupJobService.Instance.Create(newSaveJob);
        }

        private void Delete()
        {
            if (args.Count == 0)
                BackupJobService.Instance.DeleteAll();
            else
                BackupJobService.Instance.Delete(args[Parameters.Name]);
        }

        private void Execute()
        {
            if (args.Count == 0)
                BackupJobService.Instance.ExecuteAll();
            else
                BackupJobService.Instance.Execute(args[Parameters.Name]);
        }

        private void SetLang()
        {
            TraductionService.Instance.SetLanguage(args[Parameters.Lang]);
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
