using System.IO;
using EasySave.Model.Data.Job;

namespace EasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class StateLogDirector
    {
        public static StateLogDirector Instance = new StateLogDirector();
        public IStateLogBuilder Builder { get; set; }

        private StateLogDirector() { }

        public IStateLog GetNewActiveStateLog(IBackupJob saveJob, FileInfo file, string[] remainingFiles)
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

        public IStateLog GetNewEndStateLog(IBackupJob saveJob)
        {
            Builder = new EndStateLogBuilder();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState();
            return Builder.Log;
        }
    }
}
