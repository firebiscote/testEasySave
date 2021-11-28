using testEasySave.View;
using testEasySave.Controller;
using testEasySave.Model;

namespace testEasySave
{
    public class EasySave
    {
        private readonly IView view;
        private readonly IController controller;
        private readonly IModel model;

        public EasySave()
        {
            view = new MainView();
            controller = new CommandController();
            model = new MainModel();
            LinkElements();
            view.Start();
        }

        private void LinkElements()
        {
            view.Controller = controller;
            controller.View = view;
            controller.Model = model;
        }
    }
}
