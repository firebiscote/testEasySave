using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public class FullSaveJobBuilder : ISaveJobBuilder
    {
        public ISaveJob SaveJob { get; set; }

        public FullSaveJobBuilder()
        {
            SaveJob = new FullSaveJob();
        }

        public void BuildName(string name)
        {
            SaveJob.Name = name;
        }

        public void BuildSourceDirectory(string sourceDirectory)
        {
            SaveJob.SourceDirectory = sourceDirectory;
        }

        public void BuildTargetDirectory(string targetDirectory)
        {
            SaveJob.TargetDirectory = targetDirectory;
        }

        public void BuildType()
        {
            SaveJob.Type = Parameters.FullSaveJobType;
        }
    }
}
