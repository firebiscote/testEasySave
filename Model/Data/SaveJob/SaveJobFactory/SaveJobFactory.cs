using System.Collections.Generic;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;

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
                "full" => new FullSaveJob(name, sourceDirectory, targetDirectory),
                "differential" => new DifferentialSaveJob(name, sourceDirectory, targetDirectory),
                _ => throw new KeyNotFoundException()
            };
        }

        public ISaveJob GetNewSaveJob(string name, string sourceDirectory, string targetDirectory, SaveJobType type)
        {
            return type switch
            {
                SaveJobType.Full => new FullSaveJob(name, sourceDirectory, targetDirectory),
                SaveJobType.Differential => new DifferentialSaveJob(name, sourceDirectory, targetDirectory),
                _ => throw new KeyNotFoundException()
            };
        }
    }
}
