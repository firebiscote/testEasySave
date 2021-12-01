using EasySave.Model.Data.Job;

namespace EasySave.Model.Data.BackupJob.BackupJobBuilder
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