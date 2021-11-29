using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public class FullSaveJobBuilder : AbstractSaveJobBuilder
    {
        public FullSaveJobBuilder()
        {
            SaveJob = new FullSaveJob();
        }

        public override void BuildType()
        {
            SaveJob.Type = Parameters.FullSaveJobType;
        }
    }
}
