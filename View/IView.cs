using testEasySave.Controller;

namespace testEasySave.View
{
    public interface IView
    {
        public IController Controller { get; set; }

        public void Start() { }
        public void DisplaySuccess(string message) { }
        public void DisplayError(string message) { }
    }
}
