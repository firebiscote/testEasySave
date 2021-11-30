using System.Collections.Generic;
using testEasySave.Exceptions;

namespace testEasySave.Model.Services
{
    public class TraductionService : IService
    {
        public static TraductionService Instance = new TraductionService();

        private readonly List<string> availableLanguages;
        private string language;

        private TraductionService()
        {
            availableLanguages = new List<string>() { Parameters.English, Parameters.French };
            language = availableLanguages[0];
        }

        public void SetLanguage(string language)
        {
            if (!availableLanguages.Contains(language))
                throw new NotImplementedLanguageException(language);
            this.language = language;
        }

        public string GetHelpMessage()
        {
            return language switch
            {
                Parameters.English => "Here is a list of functions with their parameters:",
                Parameters.French => "Voici une liste des fonctions avec leurs paramètres :",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetSuccessMessage()
        {
            return language switch
            {
                Parameters.English => "Successful operation!",
                Parameters.French => "Opération réussie !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetExceptionMessage()
        {
            return language switch
            {
                Parameters.English => "An error has occurred!",
                Parameters.French => "Une erreur s'est produite !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetCommandNotExistExceptionMessage(string command)
        {
            return language switch
            {
                Parameters.English => "Syntax error : '" + command + "' is not a command!",
                Parameters.French => "Erreur de syntaxe : '" + command + "' n'est pas une commande !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetArgumentExceptionMessage(string name)
        {
            return language switch
            {
                Parameters.English => name + " already exists!",
                Parameters.French => name + " existe déjà !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetBackupJobNotExistExceptionMessage(string name)
        {
            return language switch
            {
                Parameters.English => name + " don't exists!",
                Parameters.French => name + " n'existe pas !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetNotEnoughSpaceExceptionMessage()
        {
            return language switch
            {
                Parameters.English => "There are too many save jobs! Please delete one before creation!",
                Parameters.French => "Il y a trop de travaux de travail de sauvegarde ! Veuillez en supprimer un avant la création !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetParameterExceptionMessage(string parameter)
        {
            return language switch
            {
                Parameters.English => "Syntax error : '" + parameter + "' parameter is missing!",
                Parameters.French => "Erreur de syntaxe : Le paramètre '" + parameter + "' est manquant !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetNotImplementedLanguageExceptionMessage(string language)
        {
            return this.language switch
            {
                Parameters.English => "The language '" + language + "' is not available!",
                Parameters.French => "Le langage '" + language + "' n'est pas disponible !",
                _ => throw new NotImplementedLanguageException()
            };
        }
    }
}
