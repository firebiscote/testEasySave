using System;
using System.Collections.Generic;
using System.Text;
using testEasySave.View;
using testEasySave.Controller;
using testEasySave.Model;

namespace testEasySave
{
    public class EasySave
    {
        private IView view;
        private IController controller;
        private IModel model;

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
