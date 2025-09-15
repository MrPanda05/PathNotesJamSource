using Godot;
using System.Collections.Generic;
using System.Text.Json;


namespace Commons.Autoloads
{
    public partial class SaveSystem : Node
    {
        public static SaveSystem Instance { get; private set; }

        public Dictionary<string, int> saveData = new Dictionary<string, int>();

        public void Save()
        {
            using var userData = FileAccess.Open("user://mySaveData.amongus", FileAccess.ModeFlags.Write);
            string serializedData = JsonSerializer.Serialize(saveData);
            userData.StoreString(serializedData);
            GD.Print(serializedData);
            userData.Close();
        }
        public void Load()
        {
            if (!FileAccess.FileExists("user://mySaveData.amongus")) return;
            using var userData = FileAccess.Open("user://mySaveData.amongus", FileAccess.ModeFlags.Read);
            var jsonStringfied = userData.GetAsText();
            var deserializedData = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonStringfied);
            foreach (var item in deserializedData)
            {
                FillDictionary(item.Key, item.Value);
            }
            userData.Close();


        }
        private void FillDictionary(string key, int value)//just cammed
        {
            if (saveData.ContainsKey(key))
            {
                saveData[key] = value;
                return;
            }
            saveData.Add(key, value);
        }
        public void AddNewField(string key, int value)
        {
            if (saveData.ContainsKey(key)) return;

            saveData.Add(key, value);
            Save();
        }
        public void Update(string key, int value)
        {
            if (!saveData.ContainsKey(key))
            {
                AddNewField(key, value);
                return;
            }
            saveData[key] = value;
            Save();
        }

        public int? GetValue(string key)
        {
            if (!saveData.ContainsKey(key)) return null;
            return saveData[key];
        }
        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            Load();
        }
    }
}
