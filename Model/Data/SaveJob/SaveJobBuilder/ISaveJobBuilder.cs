using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public interface ISaveJobBuilder
    {
        public ISaveJob SaveJob { get; set; }

        public void BuildName(string name);
        public void BuildSourceDirectory(string sourceDirectory);
        public void BuildTargetDirectory(string targetDirectory);
        public void BuildType();
    }
}
