using CaromBilliardsGame.Stolzenberg.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class UserInterfaceController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image chargeArrowSprite;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private TMP_Text shotsText;
        [SerializeField] private TMP_Text pointsText;
        [Header("Reference")]
        [SerializeField] private FloatReference pressedTimeReference;
        [SerializeField] private IntReference shotsReference;
        [SerializeField] private IntReference pointsReference;
        [SerializeField] private FloatReference timeReference;
        [SerializeField] private Color emptyColor;
        [SerializeField] private Color fullColor;
        [SerializeField] private GameObject gameOverScreenPref;

        private void Awake()
        {
            OnPointsChanged();
            OnShotsChanged();
        }

        private void Update()
        {
            SetChargeArrow();
            UpdateTimeText();
        }

        private void UpdateTimeText()
        {
            string minutes = ((int)timeReference.Value / 60).ToString("00");
            string seconds = (timeReference.Value % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;
        }

        public void OnPointsChanged()
        {
            pointsText.text = pointsReference.Value.ToString("00");
        }

        public void OnShotsChanged()
        {
            shotsText.text = shotsReference.Value.ToString("00");
        }

        public void OnGameOver()
        {
            Instantiate(gameOverScreenPref, transform);
        }

        private void SetChargeArrow()
        {
            chargeArrowSprite.color = Color.Lerp(emptyColor, fullColor, chargeArrowSprite.fillAmount);
            chargeArrowSprite.fillAmount = Mathf.Clamp01(pressedTimeReference.Value / 1);
        }
    }
}
