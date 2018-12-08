using CaromBilliardsGame.Stolzenberg.Variables;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class UserInterfaceController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Image chargeBarSprite;
        [Header("Variables")]
        [SerializeField] private FloatReference pressedTimeReference;

        private void Update()
        {
            SetChargeArrow();
        }

        private void SetChargeArrow()
        {
            chargeBarSprite.fillAmount = Mathf.Clamp01(pressedTimeReference.Value / 1);
        }
    }
}
