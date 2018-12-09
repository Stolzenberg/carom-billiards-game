using CaromBilliardsGame.Stolzenberg.Variables;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private FloatReference rotationSpeed;
        [SerializeField] private Transform target;

        private Vector3 offset;

        private void Start()
        {
            offset = transform.position - target.transform.position;
        }

        private void LateUpdate()
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset;
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
    }
}