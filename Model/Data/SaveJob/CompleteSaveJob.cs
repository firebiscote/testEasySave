using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    public class CompleteSaveJob : ISaveJob
    {
        private string name;
        private string sourceDirectory;
        private string targetDirectory;
        private string type;

        string ISaveJob.Name { get => name; }
        string ISaveJob.SourceDirectory { get => sourceDirectory; }
        string ISaveJob.TargetDirectory { get => targetDirectory; }
        string ISaveJob.Type { get => type; }

        public CompleteSaveJob() { }

        public CompleteSaveJob(string Name, string SourceDirectory, string TargetDirectory, string Type)
        {
            this.name = Name;
            this.sourceDirectory = SourceDirectory;
            this.targetDirectory = TargetDirectory;
            this.type = Type;
        }

        public CompleteSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            this.name = name;
            this.sourceDirectory = sourceDirectory;
            this.targetDirectory = targetDirectory;
            this.type = "Complete";
        }

        void ISaveJob.Execute()
        {

        }
    }
}
