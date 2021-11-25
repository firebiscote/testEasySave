using testEasySave.Model;
using testEasySave.View;

namespace testEasySave.Controller
{
    public interface IController
    {
        public IView View { get; set; }
        public IModel Model { get; set; }

        public void Transmit(string command);
    }
}
