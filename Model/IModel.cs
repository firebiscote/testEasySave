using System.Collections.Generic;

namespace testEasySave.Model
{
    public interface IModel
    {
        public void Process(string action, Dictionary<string, string> arguments);
    }
}
