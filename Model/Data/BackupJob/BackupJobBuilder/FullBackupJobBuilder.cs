using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.BackupJob.BackupJobBuilder
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
