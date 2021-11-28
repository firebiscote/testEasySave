using System;
using System.Collections.Generic;
using System.Linq;
using testEasySave.Model;
using testEasySave.Model.Services;
using testEasySave.View;

namespace testEasySave.Controller
{
    public class CommandController : IController
    {
        private string command;
        private string action;
        private Dictionary<string, string> arguments;
        public IView View { get; set; }
        public IModel Model { get; set; }

        public void Transmit(string command)
        {
            this.command = command;
            Parse();
            bool isException = false;
            try
            {
                Model.Process(action, arguments);
            }
            catch (Exception e) 
            {
                isException = true;
                HandleError(e.Message);
            }
            if (!isException)
                View.DisplaySuccess(TraductionService.Instance.GetSuccessMessage());
        }

        private void Parse()
        {
            List<string> commandSplited = command.Split(Parameters.CommandSeparator).ToList();
            action = commandSplited[0];
            arguments = new Dictionary<string, string>();
            for (int i = 1; i < commandSplited.Count()-1; i += 2)
                arguments.Add(commandSplited[i], commandSplited[i + 1]);
        }

        private void HandleError(string message)
        {
            if (message == null)
                View.DisplayError(TraductionService.Instance.GetErrorMessage());
            else
            {
                if (message.Contains(Parameters.ArgumentError))
                    View.DisplayError(TraductionService.Instance.GetParameterErrorMessage(message[(message.IndexOf(Parameters.ErrorArgumentDelimiter)+1)..message.LastIndexOf(Parameters.ErrorArgumentDelimiter)]));
                else
                    View.DisplayError(message);
            }
        }
    }
}
