namespace testEasySave.Model.Data.Log.StateLog.StateBuilder
{
    public class EndStateLogBuilder : AbstractStateLogBuilder
    {
        public EndStateLogBuilder()
        {
            Log = new StateLog();
        }

        public override void BuildState()
        {
            Log.State = Parameters.LogEndState;
        }
    }
}
