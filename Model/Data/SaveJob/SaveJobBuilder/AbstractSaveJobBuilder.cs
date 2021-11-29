using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public abstract class AbstractSaveJobBuilder : ISaveJobBuilder
    {
        public ISaveJob SaveJob { get; set; }

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

        abstract public void BuildType();
    }
}
