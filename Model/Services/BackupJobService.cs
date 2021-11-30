using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;
using testEasySave.Exceptions;

namespace testEasySave.Model.Services
{
    public class BackupJobService : IService
    {
        public static BackupJobService Instance = new BackupJobService();
        public FixedSizeDictionary<string, IBackupJob> SaveJobs { get; }

        private BackupJobService()
        {
            SetSaveJobDirectory();
            SaveJobs = new FixedSizeDictionary<string, IBackupJob>(Parameters.MaxSaveJob);
            InitSaveJobs();
        }

        private void SetSaveJobDirectory()
        {
            new DirectoryInfo(Parameters.SaveJobDirectory).Create();
        }

        private void InitSaveJobs()
        {
            foreach (string fileName in Directory.GetFiles(Parameters.SaveJobDirectory, Parameters.FilePattern))
            {
                string json = File.ReadAllText(fileName);
                IBackupJob saveJob = DeSerializeSaveJob(json);
                SaveJobs.Add(saveJob.Name, saveJob);
            }
        }

        public void Create(IBackupJob saveJob)
        {
            SaveJobs.Add(saveJob.Name, saveJob);
            string fileName = Parameters.SaveJobDirectory + saveJob.Name + Parameters.FileType;
            string json = SerializeSaveJob(saveJob);
            File.WriteAllText(fileName, json);
        }

        public void DeleteAll() {
            foreach (KeyValuePair<string, IBackupJob> saveJob in SaveJobs)
                Delete(saveJob.Key);
        }

        public void Delete(string name)
        {
            File.Delete(Parameters.SaveJobDirectory + name + Parameters.FileType);
            SaveJobs.Remove(name);
        }

        public void ExecuteAll()
        {
            foreach (KeyValuePair<string, IBackupJob> saveJob in SaveJobs)
                saveJob.Value.Execute();
        }

        public void Execute(string name)
        {
            SaveJobs[name].Execute();
        }

        private IBackupJob DeSerializeSaveJob(string json)
        {
            if (json.Contains(Parameters.FullSaveJobType))
                return JsonSerializer.Deserialize<FullBackupJob>(json);
            else if (json.Contains(Parameters.differentialSaveJobType))
                return JsonSerializer.Deserialize<DifferentialBackupJob>(json);
            else
                throw new BackupJobTypeNotImplementedException();
        }

        private string SerializeSaveJob(IBackupJob saveJob)
        {
            return JsonSerializer.Serialize(saveJob, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
