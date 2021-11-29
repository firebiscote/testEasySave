using System;
using System.Collections.Generic;
using System.Linq;
using testEasySave.Exceptions;
using testEasySave.Model;
using testEasySave.Model.Services;
using testEasySave.View;

namespace testEasySave.Controller
{
    public class CommandController : IController
    {
        private string action;
        private Dictionary<string, string> arguments;
        public IView View { get; set; }
        public IModel Model { get; set; }

        public void Transmit(string command)
        {
            ParseCommand(command);
            bool isException = false;
            try
            {
                Model.Process(action, arguments);
            }
            catch (CommandNotExistException exception)
            {
                HandleCommandNotExistException(exception);
            }
            catch (NotEnoughSpaceException)
            {
                HandleNotEnoughSpaceException();
            }
            catch (KeyNotFoundException exception)
            {
                HandleKeyNotFoundException(exception);
            }
            catch (ArgumentException exception)
            {
                HandleArgumentException(exception);
            }
            catch (NotImplementedLanguageException exception)
            {
                HandleNotImplementedLanguageException(exception);
            }
            catch (HelpException exception)
            {
                HandleHelpException(exception);
            }
            catch (ShowException exception)
            {
                HandleShowException(exception);
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
            if (!isException)
                View.DisplaySuccess(TraductionService.Instance.GetSuccessMessage());
        }

        private void ParseCommand(string command)
        {
            List<string> commandSplited = command.Split(Parameters.CommandSeparator).ToList();
            action = commandSplited[0];
            arguments = new Dictionary<string, string>();
            for (int i = 1; i < commandSplited.Count()-1; i += 2)
                arguments.Add(commandSplited[i], commandSplited[i + 1]);
        }

        private void HandleCommandNotExistException(CommandNotExistException e)
        {
            View.DisplayError(TraductionService.Instance.GetCommandNotExistExceptionMessage(e.Message));
        }

        private void HandleNotEnoughSpaceException()
        {
            View.DisplayError(TraductionService.Instance.GetNotEnoughSpaceExceptionMessage());
        }

        private void HandleKeyNotFoundException(KeyNotFoundException e)
        {
            string errorMessage = e.Message[(e.Message.IndexOf(Parameters.ErrorArgumentDelimiter) + 1)..e.Message.LastIndexOf(Parameters.ErrorArgumentDelimiter)];
            View.DisplayError(TraductionService.Instance.GetParameterExceptionMessage(errorMessage));
        }

        private void HandleArgumentException(ArgumentException e)
        {
            string name = e.Message[e.Message.LastIndexOf(' ')..];
            View.DisplayError(TraductionService.Instance.GetArgumentExceptionMessage(name));
        }

        private void HandleNotImplementedLanguageException(NotImplementedLanguageException e)
        {
            View.DisplayError(TraductionService.Instance.GetNotImplementedLanguageExceptionMessage(e.Message));
        }

        private void HandleHelpException(HelpException e)
        {
            View.Display(e.Message, ConsoleColor.Gray);
        }

        private void HandleShowException(ShowException e)
        {
            View.Display(e.Message, ConsoleColor.Gray);
        }

        private void HandleException(Exception e)
        {
            if (e.Message == null)
                View.DisplayError(TraductionService.Instance.GetExceptionMessage());
            else
                View.DisplayError(e.Message);
        }
    }
}
