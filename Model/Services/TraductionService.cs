using System.Collections.Generic;
using testEasySave.Exceptions;

namespace testEasySave.Model.Services
{
    class TraductionService : IService
    {
        private static TraductionService instance;
        public static TraductionService Instance 
        {
            get
            {
                if (instance == null)
                    instance = new TraductionService();
                return instance;
            }
        }

        private readonly List<string> availableLanguages;
        private string language;
        public string Language
        {
            get => language;
            set
            {
                if (availableLanguages.Contains(value))
                    language = value;
                else
                    throw new NotImplementedLanguageException();
            } 
        }

        private TraductionService()
        {
            availableLanguages = new List<string>() { Parameters.English, Parameters.French };
            language = Parameters.English;
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
                Parameters.English => "Successfull operation!",
                Parameters.French => "Opération réussie !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetErrorMessage()
        {
            return language switch
            {
                Parameters.English => "An error has occure!",
                Parameters.French => "Une erreur s'est produite !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetParameterErrorMessage(string parameter)
        {
            return language switch
            {
                Parameters.English => "A parameter is missing : " + parameter,
                Parameters.French => parameter + "Un paramètre est manquant : " + parameter,
                _ => throw new NotImplementedLanguageException()
            };
        }
    }
}
