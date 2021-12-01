using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.BackupJob.BackupJobBuilder
{
    public class DifferentialBackupJobBuilder : AbstractBackupJobBuilder
    {
        public DifferentialBackupJobBuilder()
        {
            BackupJob = new DifferentialBackupJob();
        }

        public override void BuildType()
        {
            BackupJob.Type = Parameters.differentialBackupJobType;
        }
    }
}