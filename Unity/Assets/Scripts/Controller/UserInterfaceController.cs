using System;
using CaromBilliardsGame.Stolzenberg.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class UserInterfaceController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Image chargeBarSprite;
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
            string minutes = ((int)timeReference.Value / 60).ToString("");
            string seconds = (timeReference.Value % 60).ToString("f0");

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

        private void SetChargeArrow()
        {
            chargeBarSprite.fillAmount = Mathf.Clamp01(pressedTimeReference.Value / 1);
            chargeBarSprite.color = Color.Lerp(emptyColor, fullColor, chargeBarSprite.fillAmount);

            chargeArrowSprite.fillAmount = Mathf.Clamp01(pressedTimeReference.Value / 1);
        }
    }
}
