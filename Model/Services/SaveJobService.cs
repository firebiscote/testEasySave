using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;

namespace testEasySave.Model.Services
{
    public class SaveJobService : IService
    {
        public FixedSizeDictionary<string, ISaveJob> saveJobs;

        public SaveJobService()
        {
            saveJobs = new FixedSizeDictionary<string, ISaveJob>(Parameters.MaxSaveJob);
            InitSaveJobs();
        }

        private void InitSaveJobs()
        {
            foreach (string fileName in Directory.GetFiles(Parameters.SaveJobDirectory, Parameters.FilePattern))
            {
                string json = File.ReadAllText(fileName);
                ISaveJob saveJob = DeSerializeSaveJob(json);
                saveJobs.Add(saveJob.Name, saveJob);
            }
        }

        public void Create(ISaveJob saveJob)
        {
            saveJobs.Add(saveJob.Name, saveJob);
            string fileName = Parameters.SaveJobDirectory + saveJob.Name + Parameters.FileType;
            string json = SerializeSaveJob(saveJob);
            File.WriteAllText(fileName, json);
        }

        public void DeleteAll() {
            foreach (KeyValuePair<string, ISaveJob> saveJob in saveJobs)
            {
                File.Delete(Parameters.SaveJobDirectory + saveJob.Key + Parameters.FileType);
                saveJobs.Remove(saveJob.Key);
            }
        }

        public void Delete(string name)
        {
            File.Delete(Parameters.SaveJobDirectory + name + Parameters.FileType);
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
            if (json.Contains(Parameters.FullSaveJobType))
                return JsonSerializer.Deserialize<FullSaveJob>(json);
            else if (json.Contains(Parameters.DifferencialSaveJobType))
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
