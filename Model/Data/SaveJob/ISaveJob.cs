using System.Collections.Generic;

namespace testEasySave.Model.Data.Job
{
    public interface ISaveJob
    {
        public string Name { get; set; }
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string Type { get; set; }

        public void Execute();

        public List<string> GetFiles();
    }
}
