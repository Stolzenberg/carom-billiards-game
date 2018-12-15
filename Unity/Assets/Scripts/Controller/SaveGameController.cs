

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [System.Serializable]
    public struct SaveGameData
    {
        public int Shots { get; internal set; }
        public int Points { get; internal set; }
        public float Time { get; internal set; }
    }

    public class SaveGameController
    {
        static string path = Application.persistentDataPath + "/game.data";

        public void SaveGame(SaveGameData saveData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, saveData);

            stream.Close();
        }

        public SaveGameData LoadGame()
        {
            SaveGameData data = new SaveGameData();

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(path, FileMode.Open);

                data = (SaveGameData)formatter.Deserialize(stream);
                stream.Close();

            }
            else
            {
                Debug.LogError("Save file not found in" + path);
            }

            return data;

        }
    }
}