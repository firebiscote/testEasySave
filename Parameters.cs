using testEasySave.Model.Services;

namespace testEasySave
{
    public static class Parameters
    {
        // directory
        public static string BaseDirectory = @"..\\..\\";
        public static string BackupJobDirectory = BaseDirectory + @"saveJob\\";
        public static string LogFileDirectory = BaseDirectory + @"log\\";
        public static string HistoryLogDirectory = LogFileDirectory + @"historyLog\\";
        public static string StateLogDirectory = LogFileDirectory + @"stateLog\\";
        public static string StateLogFile = StateLogDirectory + "state" + FileType;

        // command keyword
        public static string Show = "show";
        public static string Create = "create";
        public static string Delete = "delete";
        public static string Execute = "execute";
        public static string Language = "language";
        public static string Help = "help";
        public static string Quit = "quit";

        // command arguments
        public static string Name = "-n";
        public static string SourceDirectory = "-sd";
        public static string TargetDirectory = "-td";
        public static string Type = "-t";
        public static string Lang = "-l";
        public static string Directory = "-d";

        // language
        public const string English = "en";
        public const string French = "fr";

        // separator or specification
        public static string HistoryLogNameStart = "log";
        public static string HistoryLogDateSeparator = "/";
        public static string HistoryLogNameSeparator = "-";
        public static string HistoryLogDateFormat = "dd" + HistoryLogDateSeparator + "MM"+ HistoryLogDateSeparator + "yyyy";
        public static string LogTimestampFormat = "T";

        public static string CommandSeparator = " ";
        public static string ArgumentError = "key";
        public static string KeyErrorDelimiter = "'";
        public static string ArgumentErrorDelimiter = " ";

        public static int MaxBackupJob = 5;
        public static string FileType = ".json";
        public static string FilePattern = "*" + FileType;

        public static string BackupJobStart = " - ";
        public static string BackupJobSeparator = " : ";
        public static string DirectorySeparator = " | ";
        public static string TypeSeparator = " -> ";

        public static string JsonStart = "[";
        public static string JsonSeparator = ",\n";
        public static string JsonEnd = "]";

        // state or type
        public const string FullBackupJobType = "full";
        public const string differentialBackupJobType = "differential";
        public static string LogEndState = "END";
        public static string LogActiveState = "ACTIVE";

        // visual effects
        public static string[] Hello = new string[] { @"  ______                   _____                   __   ___   ___  ",
                                                      @" |  ____|                 / ____|                 /_ | / _ \ / _ \ ",
                                                      @" | |__   __ _ ___ _   _  | (___   __ ___   _____   | || | | | | | |",
                                                      @" |  __| / _` / __| | | |  \___ \ / _` \ \ / / _ \  | || | | | | | |",
                                                      @" | |___| (_| \__ \ |_| |  ____) | (_| |\ V /  __/  | || |_| | |_| |",
                                                      @" |______\__,_|___/\__, | |_____/ \__,_| \_/ \___|  |_(_)___(_)___/ ",
                                                      @"                   __/ |                                           ",
                                                       "                  |___/                                            "};
        public static string Introduction = "\nWelcome to your backup software ! Please type 'help' for more information !";
        public static string HelpMessage = "________________________________________________________________________\n" +
                                            TraductionService.Instance.GetHelpMessage() +
                                           "\n=> " + Show + " {" + Name + " name}" + 
                                           "\n=> " + Create + " " + Name + " name " + SourceDirectory + " sourceDirectory " + TargetDirectory + " targetDirectory " + Type + " type" +
                                           "\n=> " + Delete + " {" + Name + " name}" +
                                           "\n=> " + Execute + " {" + Name + " name}" +
                                           "\n=> " + Language + " " + Lang + " language" +
                                           "\n=> " + Quit +
                                           "\n________________________________________________________________________";
        public static string CommandIndent = "=> ";
    }
}
