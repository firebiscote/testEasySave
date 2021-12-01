using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.BackupJob.BackupJobBuilder
{
    public abstract class AbstractBackupJobBuilder : IBackupJobBuilder
    {
        public IBackupJob BackupJob { get; set; }

        public void BuildName(string name)
        {
            BackupJob.Name = name;
        }

        public void BuildSourceDirectory(string sourceDirectory)
        {
            sourceDirectory += (sourceDirectory[^1] == '\\') ? "" : @"\";
            BackupJob.SourceDirectory = sourceDirectory;
        }

        public void BuildTargetDirectory(string targetDirectory)
        {
            targetDirectory += (targetDirectory[^1] == '\\') ? "" : @"\";
            BackupJob.TargetDirectory = targetDirectory;
        }

        abstract public void BuildType();
    }
}
