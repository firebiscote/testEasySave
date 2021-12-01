using System;
using System.Collections.Generic;
using System.Linq;
using EasySave.Exceptions;
using EasySave.Model;
using EasySave.Model.Services;
using EasySave.View;

namespace EasySave.Controller
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
            catch (TooManyArgumentsException)
            {
                HandleTooManyArgumentsException();
            }
            catch (KeyNotFoundException exception)
            {
                HandleKeyNotFoundException(exception);
            }
            catch (BackupJobNotExistException exception)
            {
                HandleBackupJobNotExistException(exception);
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
            View.DisplaySuccess(TraductionService.Instance.GetSuccessMessage());
        }

        private void ParseCommand(string command)
        {
            List<string> commandSplited = command.Split(Parameters.CommandSeparator).ToList();
            action = commandSplited[0];
            arguments = new Dictionary<string, string>();
            for (int i = 1; i < commandSplited.Count(); i += 2)
                arguments.Add(commandSplited[i], (i + 1 == commandSplited.Count()) ? null : commandSplited[i + 1]);
        }

        private void HandleCommandNotExistException(CommandNotExistException e)
        {
            View.DisplayError(TraductionService.Instance.GetCommandNotExistExceptionMessage(e.Message));
        }

        private void HandleNotEnoughSpaceException()
        {
            View.DisplayError(TraductionService.Instance.GetNotEnoughSpaceExceptionMessage());
        }

        private void HandleTooManyArgumentsException()
        {
            View.DisplayError(TraductionService.Instance.GetTooManyArgumentsExceptionMessage());
        }

        private void HandleKeyNotFoundException(KeyNotFoundException e)
        {
            // Get the wrong key
            string errorMessage = e.Message[(e.Message.IndexOf(Parameters.KeyErrorDelimiter) + 1)..e.Message.LastIndexOf(Parameters.KeyErrorDelimiter)];
            View.DisplayError(TraductionService.Instance.GetParameterExceptionMessage(errorMessage));
        }

        private void HandleBackupJobNotExistException(BackupJobNotExistException e)
        {
            View.DisplayError(TraductionService.Instance.GetBackupJobNotExistExceptionMessage(e.Message));
        }

        private void HandleArgumentException(ArgumentException e)
        {
            // Get the wrong argument
            string name = e.Message[e.Message.LastIndexOf(Parameters.ArgumentErrorDelimiter)..];
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
