using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using testEasySave.Model.Data.Job;

namespace testEasySave.Model.Service
{
    public class SaveJobService : IService
    {
        private const int MAX_SAVE_JOB = 5;
        private const string FILE = ".json";
        private const string FILE_PATTERN = "*" + FILE;
        private const string SAVE_JOB_PATH = "C:\\\\Users\\\\maxim\\\\Desktop\\\\test\\\\saveJob\\\\";
        public FixedSizeDictionary<string, ISaveJob> saveJobs;

        public SaveJobService()
        {
            saveJobs = new FixedSizeDictionary<string, ISaveJob>(MAX_SAVE_JOB);
            InitSaveJobs();
        }

        private void InitSaveJobs()
        {
            foreach (string fileName in Directory.GetFiles(SAVE_JOB_PATH, FILE_PATTERN))
            {
                string json = File.ReadAllText(fileName);
                ISaveJob saveJob = DeSerializeSaveJob(json);
                saveJobs.Add(saveJob.Name, saveJob);
            }
        }

        public void CreateSaveJob(ISaveJob saveJob)
        {
            saveJobs.Add(saveJob.Name, saveJob);
            string fileName = SAVE_JOB_PATH + saveJob.Name + FILE;
            string json = SerializeSaveJob(saveJob);
            File.WriteAllText(fileName, json);
        }

        public void DeleteSaveJob(string name)
        {
            File.Delete(SAVE_JOB_PATH + name + FILE);
            saveJobs.Remove(name);
        }

        public void ExecuteAll()
        {
            foreach (KeyValuePair<string, ISaveJob> saveJob in saveJobs)
                saveJob.Value.Execute();
        }

        public void Execute(string name)
        {
            saveJobs[name].Execute();
        }

        private ISaveJob DeSerializeSaveJob(string json)
        {
            if (json.Contains("Complete"))
                return JsonSerializer.Deserialize<CompleteSaveJob>(json);
            else if (json.Contains("Differential"))
                return JsonSerializer.Deserialize<DifferentialSaveJob>(json);
            else
                throw new Exception();
        }

        private string SerializeSaveJob(ISaveJob saveJob)
        {
            return JsonSerializer.Serialize(saveJob);
        }
    }
}
