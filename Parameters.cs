﻿namespace testEasySave
{
    public static class Parameters
    {
        public static int MaxSaveJob = 5;
        public static string FileType = ".json";
        public static string FilePattern = "*" + FileType;
        public static string SaveJobDirectory = "C:\\\\Users\\\\maxim\\\\Desktop\\\\test\\\\saveJob\\\\";
        public static string CommandSeparator = " ";
        public static string ErrorArgumentDelimiter = "'";
        public const string FullSaveJobType = "full";
        public const string DifferencialSaveJobType = "differential";
        public static string LogEndState = "END";
        public static string LogActiveState = "ACTIVE";
        public static string HistoryLogDirectory = "C:\\\\Users\\\\maxim\\\\Desktop\\\\test\\\\log\\\\historyLog\\\\";
        public const string English = "en";
        public const string French = "fr";
        public static readonly string VARIABLE;

        // visual effects
        public static string[] Hello = new string[] { @"  ______                   _____                   __   ___   ___  ",
                                                      @" |  ____|                 / ____|                 /_ | / _ \ / _ \ ",
                                                      @" | |__   __ _ ___ _   _  | (___   __ ___   _____   | || | | | | | |",
                                                      @" |  __| / _` / __| | | |  \___ \ / _` \ \ / / _ \  | || | | | | | |",
                                                      @" | |___| (_| \__ \ |_| |  ____) | (_| |\ V /  __/  | || |_| | |_| |",
                                                      @" |______\__,_|___/\__, | |_____/ \__,_| \_/ \___|  |_(_)___(_)___/ ",
                                                      @"                   __/ |                                           ",
                                                       "                  |___/                                            \n\n\n\n\n"};
        public static string CommandIndent = "=> ";

        // command keyword
        public static string Create = "create";
        public static string Delete = "delete";
        public static string Execute = "execute";
        public static string SetLang = "setLang";
        public static string SetLogDirectory = "setLogDirectory";
        public static string Help = "help";
        public static string Quit = "quit";

        // command arguments
        public static string Name = "-n";
        public static string SourceDirectory = "-sd";
        public static string TargetDirectory = "-td";
        public static string Type = "-t";
        public static string Lang = "-l";
        public static string Directory = "-d";

    }
}