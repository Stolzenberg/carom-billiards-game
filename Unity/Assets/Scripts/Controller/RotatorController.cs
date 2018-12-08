using CaromBilliardsGame.Stolzenberg.Variables;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class RotatorController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private FloatReference rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed.Value * Time.deltaTime, Space.World);
        }
    }
}
