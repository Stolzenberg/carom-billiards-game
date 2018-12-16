using CaromBilliardsGame.Stolzenberg.Variables;
using TMPro;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class GameOverScreenController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private TMP_Text shotsText;
        [SerializeField] private TMP_Text timerText;
        [Header("References")]
        [SerializeField] private IntReference shotsReference;
        [SerializeField] private FloatReference timeReference;

        private void Awake()
        {
            UpdateTimeText();
            UpdateShotCountText();

            Cursor.visible = true;
        }

        private void UpdateTimeText()
        {
            string minutes = ((int)timeReference.Value / 60).ToString("00");
            string seconds = (timeReference.Value % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }

        private void UpdateShotCountText()
        {
            shotsText.text = shotsReference.Value.ToString("00");
        }
    }
}