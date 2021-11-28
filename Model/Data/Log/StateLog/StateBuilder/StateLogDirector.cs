using System.IO;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class StateLogDirector
    {
        public static StateLogDirector Instance = new StateLogDirector();
        public IStateLogBuilder Builder { get; set; }

        private StateLogDirector()
        {
            Builder = new StateLogBuilder();
        }

        public IStateLog GetNewActiveStateLog(ISaveJob saveJob, FileInfo file, string[] remainingFiles)
        {
            Builder.Reset();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState(Parameters.LogActiveState);
            Builder.BuildTotalTargetedFiles(saveJob.SourceDirectory);
            Builder.BuildTotalTargetedFilesSize();
            Builder.BuildProgress(remainingFiles, file.FullName, saveJob.TargetDirectory + file.Name);
            return Builder.Log;
        }

        public IStateLog GetNewEndStateLog(ISaveJob saveJob)
        {
            Builder.Reset();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState(Parameters.LogEndState);
            return Builder.Log;
        }
    }
}
