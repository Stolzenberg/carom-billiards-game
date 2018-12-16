using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [System.Serializable]
    public struct SaveGameData
    {
        public int Shots;
        public int Points;
        public float Time;
    }

    public class SaveGameController
    {
        static string SAVE_GAME = "SAVE_GAME";

        public static void SaveGame(SaveGameData saveData)
        {
            string saveString = JsonUtility.ToJson(saveData);
            PlayerPrefs.SetString(SAVE_GAME, saveString);
        }

        public static SaveGameData LoadGame()
        {
            SaveGameData data = new SaveGameData();

            if (PlayerPrefs.HasKey(SAVE_GAME))
            {
                string saveString = PlayerPrefs.GetString(SAVE_GAME);
                Debug.Log("Load Data");

                data = JsonUtility.FromJson<SaveGameData>(saveString);
            }
            else
            {
                Debug.LogError("Save file not found!");
            }

            return data;
        }
    }
}