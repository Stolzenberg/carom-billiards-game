using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        internal bool IsMoving { get; set; }

        [Header("Model")]
        [SerializeField] private BallModel ballModel;
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;
        [SerializeField] private Rigidbody rigid;
        [SerializeField] private Transform viewTransform;
        
        private float velocity;

        private void Awake()
        {
            sphereCol.radius = ballModel.Size / 2;
            viewTransform.localScale = Vector3.one * ballModel.Size;
            rigid.drag = ballModel.Drag;
        }

        private void Update()
        {
            CheckIfMoving();
        }
 
        internal void ApplyForceToBall(Vector3 direction, float velocity)
        {
            rigid.AddForce(direction * velocity, ForceMode.Impulse);
        }

        private void CheckIfMoving()
        {
            if (rigid.velocity.magnitude <= 1)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
            }
        }
    }
}