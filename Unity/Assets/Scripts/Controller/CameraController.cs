using CaromBilliardsGame.Stolzenberg.Variables;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private FloatReference rotationSpeed;
        [SerializeField] private Transform target;

        private Vector3 offset;

        private void Start()
        {
            offset = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }

        private void LateUpdate()
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset;
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
    }
}