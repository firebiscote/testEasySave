using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public class DifferentialSaveJobBuilder : AbstractSaveJobBuilder
    {
        public DifferentialSaveJobBuilder()
        {
            SaveJob = new DifferentialSaveJob();
        }

        public override void BuildType()
        {
            SaveJob.Type = Parameters.differentialSaveJobType;
        }
    }
}