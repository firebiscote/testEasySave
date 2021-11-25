using System.Collections.Generic;
using testEasySave.Exceptions;

namespace testEasySave.Model.Service
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

        private const string ENGLISH = "en";
        private const string FRENCH = "fr";
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
            availableLanguages = new List<string>() { ENGLISH, FRENCH };
            language = ENGLISH;
        }

        public string GetHelpMessage()
        {
            return language switch
            {
                ENGLISH => "Here is a list of functions with their parameters:",
                FRENCH => "Voici une liste des fonctions avec leurs paramètres :",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetSuccessMessage()
        {
            return language switch
            {
                ENGLISH => "Successfull operation!",
                FRENCH => "Opération réussie !",
                _ => throw new NotImplementedLanguageException()
            };
        }

        public string GetErrorMessage()
        {
            return language switch
            {
                ENGLISH => "An error has occure!",
                FRENCH => "Une erreur s'est produite !",
                _ => throw new NotImplementedLanguageException()
            };
        }
    }
}
