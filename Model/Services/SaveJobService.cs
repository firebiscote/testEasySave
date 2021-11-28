using System;
using System.IO;
using System.Collections.Generic;
using testEasySave.Model.Data.Job;
using testEasySave.Model.Data.ToolBox;
using Newtonsoft.Json;

namespace testEasySave.Model.Services
{
    public class SaveJobService : IService
    {
        public static SaveJobService Instance = new SaveJobService();
        public FixedSizeDictionary<string, ISaveJob> SaveJobs { get; }

        private SaveJobService()
        {
            SaveJobs = new FixedSizeDictionary<string, ISaveJob>(Parameters.MaxSaveJob);
            InitSaveJobs();
        }

        private void InitSaveJobs()
        {
            foreach (string fileName in Directory.GetFiles(Parameters.SaveJobDirectory, Parameters.FilePattern))
            {
                string json = File.ReadAllText(fileName);
                ISaveJob saveJob = DeSerializeSaveJob(json);
                SaveJobs.Add(saveJob.Name, saveJob);
            }
        }

        public void Create(ISaveJob saveJob)
        {
            SaveJobs.Add(saveJob.Name, saveJob);
            string fileName = Parameters.SaveJobDirectory + saveJob.Name + Parameters.FileType;
            string json = SerializeSaveJob(saveJob);
            File.WriteAllText(fileName, json);
        }

        public void DeleteAll() {
            foreach (KeyValuePair<string, ISaveJob> saveJob in SaveJobs)
                Delete(saveJob.Key);
        }

        public void Delete(string name)
        {
            File.Delete(Parameters.SaveJobDirectory + name + Parameters.FileType);
            SaveJobs.Remove(name);
        }

        public void ExecuteAll()
        {
            foreach (KeyValuePair<string, ISaveJob> saveJob in SaveJobs)
                saveJob.Value.Execute();
        }

        public void Execute(string name)
        {
            SaveJobs[name].Execute();
        }

        private ISaveJob DeSerializeSaveJob(string json)
        {
            if (json.Contains(Parameters.FullSaveJobType))
                return JsonConvert.DeserializeObject<FullSaveJob>(json);
            else if (json.Contains(Parameters.DifferencialSaveJobType))
                return JsonConvert.DeserializeObject<DifferentialSaveJob>(json);
            else
                throw new Exception();
        }

        private string SerializeSaveJob(ISaveJob saveJob)
        {
            return JsonConvert.SerializeObject(saveJob, Formatting.Indented);
        }
    }
}
