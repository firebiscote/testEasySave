using System;
using System.Collections.Generic;
using System.Text;

namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class StateLogBuilder : IStateLogBuilder
    {
        public IStateLog Log { get; set; }

        public void Reset()
        {
            Log = new StateLog();
        }

        public void BuildSaveJobName(string name)
        {
            Log.SaveJobName = name;
        }

        public void BuildTimestamp()
        {
            Log.Timestamp = DateTime.Now.ToString(Parameters.HistoryLogTimestampFormat);
        }

        public void BuildState(bool active)
        {
            if (active)
                Log.State = Parameters.LogActiveState;
            else
                Log.State = Parameters.LogEndState;
        }

        public void BuildTotalFilesTargeted()
        {

        }

        public void BuildTotalFilesTargetedSize()
        {

        }

        public void BuildProgress()
        {

        }
    }
}
