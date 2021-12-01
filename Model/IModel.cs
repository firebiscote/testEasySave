using System.Collections.Generic;

namespace EasySave.Model
{
    public interface IModel
    {
        public void Process(string action, Dictionary<string, string> arguments);
    }
}
