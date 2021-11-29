using System.IO;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class StateLogDirector
    {
        public static StateLogDirector Instance = new StateLogDirector();
        public IStateLogBuilder Builder { get; set; }

        private StateLogDirector() { }

        public IStateLog GetNewActiveStateLog(ISaveJob saveJob, FileInfo file, string[] remainingFiles)
        {
            Builder = new ActiveStateLogBuilder();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState();
            Builder.BuildTotalTargetedFiles(saveJob.SourceDirectory);
            Builder.BuildTotalTargetedFilesSize();
            Builder.BuildProgress(remainingFiles, file.FullName, saveJob.TargetDirectory + file.FullName[saveJob.SourceDirectory.Length..]);
            return Builder.Log;
        }

        public IStateLog GetNewEndStateLog(ISaveJob saveJob)
        {
            Builder = new EndStateLogBuilder();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState();
            return Builder.Log;
        }
    }
}
