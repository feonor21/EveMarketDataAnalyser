using EveMarketDataAnalyser.Code.ClassPub;
using MarketDataAnalyser.Code.ClassPub;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MarketDataAnalyser
{
    public class cConfig
    {
        private static cConfig instance = null;
        private static readonly object padlock = new object();
        public static cConfig Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) { instance = new cConfig(); }
                    return instance;
                }
            }
        }
        private cConfig()
        {
            instance = this;
        }
        public static string getPathFile() { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MarketDataAnalyser.json"; }


        public string EsiCLientId = null;
        public string EsiSecret = null;
        public string token = null;


        public long structureID { get; set; }
        public List<Structure> AllStructureId { get; set; }

        public cConfigData Data = new cConfigData();


        public void ExportData(string outputPath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            if (!File.Exists(outputPath))
                File.Create(outputPath).Close();

            using (StreamWriter sw = new StreamWriter(outputPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this.Data);
            }

        }
        public void ExportStructure(string outputPath)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            if (!File.Exists(outputPath))
                File.Create(outputPath).Close();

            using (StreamWriter sw = new StreamWriter(outputPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this.AllStructureId);
            }

        }

        public void SerialConfig()
        {

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(getPathFile()))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
            }
        }
        public static cConfig DeserialConfig()
        {
            cConfig result;
            
            if (!File.Exists(getPathFile()))
            {
                result = cConfig.Instance;
                result.SerialConfig();
            }

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(getPathFile()))
            {
                JsonSerializer serializer = new JsonSerializer();
                result = (cConfig)serializer.Deserialize(file, typeof(cConfig));
            }

            return result;
        }
    }

    public class cConfigData
    {

        public List<MarketItem> ListItem = new List<MarketItem>();
        [JsonIgnore]
        public List<MarketGroup> ListMarketGroup = new List<MarketGroup>();
        public List<Doctrine> Doctrines = new List<Doctrine>();
    }
}
