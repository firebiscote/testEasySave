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

        public IStateLog GetNewStateLog(ISaveJob saveJob, FileInfo file)
        {
            Builder.Reset();
            Builder.BuildTimestamp();
            Builder.BuildSaveJobName(saveJob.Name);
            Builder.BuildState(true);
            if (true)
            {
                Builder.BuildTotalFilesTargeted();
                Builder.BuildTotalFilesTargetedSize();
                Builder.BuildProgress();
            }
            return Builder.Log;
        }
    }
}
