using System;
using System.Collections.Generic;
using EasySave.Exceptions;
using EasySave.Model.Data.Job;
using EasySave.Model.Data.BackupJob.BackupJobBuilder;
using EasySave.Model.Services;

namespace EasySave.Model
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
            AreThereTooManyArguments(Parameters.TotalShowArguments);
            string saveJobsList = "\n";
            foreach (IBackupJob saveJob in BackupJobService.Instance.BackupJobs.Values)
                saveJobsList += Parameters.BackupJobStart + saveJob.Name + Parameters.BackupJobSeparator + saveJob.SourceDirectory + Parameters.DirectorySeparator + saveJob.TargetDirectory + Parameters.TypeSeparator + saveJob.Type + "\n";
            throw new ShowException(saveJobsList);
        }

        private void Create()
        {
            AreThereTooManyArguments(Parameters.TotalCreateArguments);
            IBackupJob newSaveJob = BackupJobDirector.Instance.GetNewSaveJob(args[Parameters.Name], args[Parameters.SourceDirectory], args[Parameters.TargetDirectory], args[Parameters.Type]);
            BackupJobService.Instance.Create(newSaveJob);
        }

        private void Delete()
        {
            AreThereTooManyArguments(Parameters.TotalDeleteArguments);
            if (args.Count == 0)
                BackupJobService.Instance.DeleteAll();
            else
                BackupJobService.Instance.Delete(args[Parameters.Name]);
        }

        private void Execute()
        {
            AreThereTooManyArguments(Parameters.TotalExecuteArguments);
            if (args.Count == 0)
                BackupJobService.Instance.ExecuteAll();
            else
                BackupJobService.Instance.Execute(args[Parameters.Name]);
        }

        private void SetLang()
        {
            AreThereTooManyArguments(Parameters.TotalLanguageArguments);
            TraductionService.Instance.SetLanguage(args[Parameters.Lang]);
        }

        private void Help()
        {
            AreThereTooManyArguments(Parameters.TotalHelpArguments);
            throw new HelpException(Parameters.HelpMessage);
        }

        private void Quit()
        {
            AreThereTooManyArguments(Parameters.TotalQuitArguments);
            Environment.Exit(0);
        }

        private void AreThereTooManyArguments(int reference)
        {
            if (args.Count > reference)
                throw new TooManyArgumentsException();
        }
    }
}
