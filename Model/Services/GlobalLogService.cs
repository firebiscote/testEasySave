using System.Collections.Generic;
using EasySave.Model.Data.Job;
using EasySave.Model.Data.ToolBox;

namespace EasySave.Model.Services
{
    public class GlobalLogService : ILogService
    {
        public static GlobalLogService Instance = new GlobalLogService();
        private readonly List<ILogService> logServices;

        private GlobalLogService()
        {
            logServices = new List<ILogService>() { new HistoryLogService(), new StateLogService() };
            FullBackupJob.FileCopied += Handle;
            DifferentialBackupJob.FileCopied += Handle;
        }

        public void Handle(object sender, CopyFileEventArgs args)
        {
            foreach (ILogService service in logServices)
                service.Handle(sender, args);
        }
    }
}
