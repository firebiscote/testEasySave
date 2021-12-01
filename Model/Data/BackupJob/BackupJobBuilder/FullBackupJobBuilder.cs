using EasySave.Model.Data.Job;

namespace EasySave.Model.Data.BackupJob.BackupJobBuilder
{
    public class FullBackupJobBuilder : AbstractBackupJobBuilder
    {
        public FullBackupJobBuilder()
        {
            BackupJob = new FullBackupJob();
        }

        public override void BuildType()
        {
            BackupJob.Type = Parameters.FullBackupJobType;
        }
    }
}
