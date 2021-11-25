using System;
using System.Collections.Generic;
using System.Text;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.SaveJob.SaveJobFactory;
using testEasySave.Model.Service;

namespace testEasySave.Model
{
    public class MainModel : IModel
    {
        private SaveJobService saveJobService;

        public MainModel()
        {
            saveJobService = new SaveJobService();
        }

        public void Process(string action, Dictionary<string, string> args)
        {
            switch (action.ToLower())
            {
                case "create":
                    ISaveJob newSaveJob = SaveJobFactory.Instance.GetNewSaveJob(args["-n"], args["-sd"], args["-td"], args["-t"]);
                    saveJobService.CreateSaveJob(newSaveJob);
                    break;
                case "delete":
                    saveJobService.DeleteSaveJob(args["-n"]);
                    break;
                case "execute":
                    if (args == null)
                        saveJobService.ExecuteAll();
                    else
                        saveJobService.Execute(args["-n"]);
                default:
                    break;
            }
        }
    }
}
