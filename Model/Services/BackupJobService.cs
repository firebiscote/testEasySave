using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using EasySave.Model.Data.Job;
using EasySave.Model.Data.ToolBox;
using EasySave.Exceptions;

namespace EasySave.Model.Services
{
    public class BackupJobService : IService
    {
        public static BackupJobService Instance = new BackupJobService();
        public FixedSizeDictionary<string, IBackupJob> BackupJobs { get; }

        private BackupJobService()
        {
            SetBackupJobDirectory();
            BackupJobs = new FixedSizeDictionary<string, IBackupJob>(Parameters.MaxBackupJob);
            InitBackupJobs();
        }

        private void SetBackupJobDirectory()
        {
            new DirectoryInfo(Parameters.BackupJobDirectory).Create();
        }

        private void InitBackupJobs()
        {
            foreach (string fileName in Directory.GetFiles(Parameters.BackupJobDirectory, Parameters.FilePattern))
            {
                string json = File.ReadAllText(fileName);
                IBackupJob saveJob = DeSerializeBackupJob(json);
                BackupJobs.Add(saveJob.Name, saveJob);
            }
        }

        public void Create(IBackupJob saveJob)
        {
            BackupJobs.Add(saveJob.Name, saveJob);
            string fileName = Parameters.BackupJobDirectory + saveJob.Name + Parameters.FileType;
            string json = SerializeBackupJob(saveJob);
            File.WriteAllText(fileName, json);
        }

        public void DeleteAll() {
            foreach (KeyValuePair<string, IBackupJob> saveJob in BackupJobs)
                Delete(saveJob.Key);
        }

        public void Delete(string name)
        {
            DoesItExist(name);
            File.Delete(Parameters.BackupJobDirectory + name + Parameters.FileType);
            BackupJobs.Remove(name);
        }

        public void ExecuteAll()
        {
            foreach (KeyValuePair<string, IBackupJob> backupJob in BackupJobs)
                backupJob.Value.Execute();
        }

        public void Execute(string name)
        {
            DoesItExist(name);
            BackupJobs[name].Execute();
        }

        private void DoesItExist(string name)
        {
            foreach (KeyValuePair<string, IBackupJob> backupJob in BackupJobs)
                if (name == backupJob.Key)
                    return;
            throw new BackupJobNotExistException(name);
        }

        private IBackupJob DeSerializeBackupJob(string json)
        {
            if (json.Contains(Parameters.FullBackupJobType))
                return JsonSerializer.Deserialize<FullBackupJob>(json);
            else if (json.Contains(Parameters.differentialBackupJobType))
                return JsonSerializer.Deserialize<DifferentialBackupJob>(json);
            else
                throw new BackupJobTypeNotImplementedException();
        }

        private string SerializeBackupJob(IBackupJob saveJob)
        {
            return JsonSerializer.Serialize(saveJob, Parameters.SerializerOptions);
        }
    }
}
