using System;
using System.Collections.Generic;
using System.Text;
using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.SaveJob.SaveJobFactory;
using testEasySave.Model.Services;

namespace testEasySave.Model
{
    public class MainModel : IModel
    {
        private SaveJobService saveJobService;
        private LogService logService;
        private Dictionary<string, string> args;
        private Dictionary<string, Action> actions;

        public MainModel()
        {
            saveJobService = new SaveJobService();
            logService = new LogService();
            InitActions();
        }

        private void InitActions()
        {
            actions = new Dictionary<string, Action>
            {
                { Parameters.Create, Create },
                { Parameters.Delete, Delete },
                { Parameters.Execute, Execute },
                { Parameters.SetLang, SetLang },
                { Parameters.SetLogDirectory, SetLogPath },
                { Parameters.Help, Help },
                { Parameters.Quit, Quit },
            };
        }

        public void Process(string action, Dictionary<string, string> arguments)
        {
            this.args = arguments;
            actions[action].Invoke();
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
            TraductionService.Instance.Language = args[Parameters.Lang];
        }

        private void SetLogPath()
        {
            throw new NotImplementedException();
        }

        private void Help()
        {
            throw new Exception(TraductionService.Instance.GetHelpMessage() +
                                "\n=> " + Parameters.Create + " " + Parameters.Name + " name " + Parameters.SourceDirectory + " sourceDirectory " + Parameters.TargetDirectory + " targetDirectory " + Parameters.Type + " type" +
                                "\n=> " + Parameters.Delete + " {" + Parameters.Name + " name}" +
                                "\n=> " + Parameters.Execute + " {" + Parameters.Name + " name}" +
                                "\n=> " + Parameters.SetLang + " " + Parameters.Lang + " language" +
                                "\n=> " + Parameters.Quit);
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
