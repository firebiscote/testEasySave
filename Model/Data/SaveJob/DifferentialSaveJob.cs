using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Data.Job
{
    class DifferentialSaveJob : ISaveJob
    {
        private string name;
        private string sourceDirectory;
        private string targetDirectory;
        private string type;

        string ISaveJob.Name { get => name; }
        string ISaveJob.SourceDirectory { get => sourceDirectory; }
        string ISaveJob.TargetDirectory { get => targetDirectory; }
        string ISaveJob.Type { get => type; }

        private DifferentialSaveJob() { }

        public DifferentialSaveJob(string name, string sourceDirectory, string targetDirectory)
        {
            this.name = name;
            this.sourceDirectory = sourceDirectory;
            this.targetDirectory = targetDirectory;
            this.type = "Differential";
        }

        void ISaveJob.Execute()
        {

        }
    }
}
