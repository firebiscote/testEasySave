using testEasySave.Exceptions;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobBuilder
{
    public class SaveJobDirector
    {
        public static SaveJobDirector Instance = new SaveJobDirector();
        public ISaveJobBuilder Builder { get; set; }

        private SaveJobDirector() { }

        public ISaveJob GetNewSaveJob(string name, string sourceDirectory, string targetDirectory, string type)
        {
            return type switch
            {
                Parameters.FullSaveJobType => GetNewFullSaveJob(name, sourceDirectory, targetDirectory),
                Parameters.differentialSaveJobType => GetNewDifferentialSaveJob(name, sourceDirectory, targetDirectory),
                _ => throw new SaveJobTypeNotImplementedException()
            };
        }

        public ISaveJob GetNewFullSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Builder = new FullSaveJobBuilder();
            Builder.BuildName(name);
            Builder.BuildSourceDirectory(sourceDirectory);
            Builder.BuildTargetDirectory(targetDirectory);
            Builder.BuildType();
            return Builder.SaveJob;
        }
        
        public ISaveJob GetNewDifferentialSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            Builder = new DifferentialSaveJobBuilder();
            Builder.BuildName(name);
            Builder.BuildSourceDirectory(sourceDirectory);
            Builder.BuildTargetDirectory(targetDirectory);
            Builder.BuildType();
            return Builder.SaveJob;
        }
    }
}
