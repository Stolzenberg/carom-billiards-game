using TMPro;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class Stats : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text shotsText;
        [SerializeField] private TMP_Text pointsText;

        private SaveGameController saveController;


        private void Awake()
        {
            saveController = new SaveGameController();

            SaveGameData data = saveController.LoadGame();

            shotsText.text = data.Shots.ToString("00");
            pointsText.text = data.Points.ToString("00");

            string minutes = ((int)data.Time / 60).ToString("00");
            string seconds = (data.Time % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }
    }
}