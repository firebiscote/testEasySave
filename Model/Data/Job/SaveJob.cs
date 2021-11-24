using System;
using System.Collections.Generic;
using System.Text;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    public class SaveJob : IJob
    {
        public static int TotalSaveJob;
        public string Name { get; }
        public string SourceDirectory { get; }
        public string TargetDirectory { get; }
        public SaveJobType Type { get; }

        public SaveJob(string name, string sourceDirectory, string targetDirectory, SaveJobType type)
        {
            Name = name;
            SourceDirectory = sourceDirectory;
            TargetDirectory = targetDirectory;
            Type = type;
        }
    }
}
