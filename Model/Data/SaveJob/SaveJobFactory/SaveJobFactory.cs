using System.Collections.Generic;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.SaveJob.SaveJobFactory
{
    public class SaveJobFactory : ISaveJobFactory
    {
        public static SaveJobFactory Instance = new SaveJobFactory();

        private SaveJobFactory() { }

        public ISaveJob GetNewSaveJob(string name, string sourceDirectory, string targetDirectory, string type)
        {
            return type.ToLower() switch
            {
                Parameters.FullSaveJobType => new FullSaveJob(name, sourceDirectory, targetDirectory),
                Parameters.DifferencialSaveJobType => new DifferentialSaveJob(name, sourceDirectory, targetDirectory),
                _ => throw new KeyNotFoundException()
            };
        }
    }
}
