using EasySave.Model;
using EasySave.View;

namespace EasySave.Controller
{
    public interface IController
    {
        public IView View { get; set; }
        public IModel Model { get; set; }

        public void Transmit(string command);
    }
}
