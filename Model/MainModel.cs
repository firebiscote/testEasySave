using System;
using System.Collections.Generic;
using System.Text;
using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.SaveJob.SaveJobFactory;
using testEasySave.Model.Service;

namespace testEasySave.Model
{
    public class MainModel : IModel
    {
        private SaveJobService saveJobService;
        private Dictionary<string, string> args;
        private Dictionary<string, Action> actions;

        public MainModel()
        {
            saveJobService = new SaveJobService();
            InitActions();
        }

        private void InitActions()
        {
            actions = new Dictionary<string, Action>
            {
                { "create", Create },
                { "delete", Delete },
                { "execute", Execute },
                { "setLang", SetLang },
                { "help", Help },
                { "quit", Quit }
            };
        }

        public void Process(string action, Dictionary<string, string> arguments)
        {
            this.args = arguments;
            actions[action].Invoke();
        }

        private void Create()
        {
            ISaveJob newSaveJob = SaveJobFactory.Instance.GetNewSaveJob(args["-n"], args["-sd"], args["-td"], args["-t"]);
            saveJobService.Create(newSaveJob);
        }

        private void Delete()
        {
            if (args.Count == 0)
                saveJobService.DeleteAll();
            else
                saveJobService.Delete(args["-n"]);
        }

        private void Execute()
        {
            if (args.Count == 0)
                saveJobService.ExecuteAll();
            else
                saveJobService.Execute(args["-n"]);
        }

        private void SetLang()
        {
            TraductionService.Instance.Language = args["-l"];
        }

        private void Help()
        {
            throw new Exception(TraductionService.Instance.GetHelpMessage() +
                                "\n=> create -n name -sd sourceDirectory -td targetDirectory -t type" +
                                "\n=> delete {-n name}" +
                                "\n=> execute {-n name}" +
                                "\n=> setLang -l language" +
                                "\n=> quit");
        }

        private void Quit()
        {
            Environment.Exit(0);
        }
    }
}
