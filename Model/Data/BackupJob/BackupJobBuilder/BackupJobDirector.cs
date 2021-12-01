using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.BackupJob.BackupJobBuilder
{
    public class BackupJobDirector
    {
        public static BackupJobDirector Instance = new BackupJobDirector();
        public IBackupJobBuilder Builder { get; set; }

        private BackupJobDirector() { }

        public IBackupJob GetNewSaveJob(string name, string sourceDirectory, string targetDirectory, string type)
        {
            return type switch
            {
                Parameters.FullBackupJobType => GetNewFullSaveJob(name, sourceDirectory, targetDirectory),
                Parameters.differentialBackupJobType => GetNewDifferentialSaveJob(name, sourceDirectory, targetDirectory),
                _ => throw new BackupJobTypeNotImplementedException()
            };
        }

        public IBackupJob GetNewFullSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Builder = new FullBackupJobBuilder();
            Builder.BuildName(name);
            Builder.BuildSourceDirectory(sourceDirectory);
            Builder.BuildTargetDirectory(targetDirectory);
            Builder.BuildType();
            return Builder.BackupJob;
        }
        
        public IBackupJob GetNewDifferentialSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Builder = new DifferentialBackupJobBuilder();
            Builder.BuildName(name);
            Builder.BuildSourceDirectory(sourceDirectory);
            Builder.BuildTargetDirectory(targetDirectory);
            Builder.BuildType();
            return Builder.BackupJob;
        }
    }
}
