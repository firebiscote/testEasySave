using EasySave.Model.Data.Job;

namespace EasySave.Model.Data.BackupJob.BackupJobBuilder
{
    public interface IBackupJobBuilder
    {
        public IBackupJob BackupJob { get; set; }

        public void BuildName(string name);
        public void BuildSourceDirectory(string sourceDirectory);
        public void BuildTargetDirectory(string targetDirectory);
        public void BuildType();
    }
}
