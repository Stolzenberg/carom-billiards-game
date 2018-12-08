using CaromBilliardsGame.Stolzenberg.Events;
using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        internal bool IsMoving { get; set; }
        internal BallModel BallModel { get { return ballModel; } }

        [Header("Model")]
        [SerializeField] private BallModel ballModel;
        [Header("Controllers")]
        [SerializeField] private AudioController audioController;
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;
        [SerializeField] private Rigidbody rigid;
        [SerializeField] private Transform viewTransform;
        [Header("Events")]
        [SerializeField] private GameEvent ballHitBall;
        [SerializeField] private GameEvent ballHitWall;

        private float velocity;

        private void Awake()
        {
            sphereCol.radius = BallModel.Size / 2;
            viewTransform.localScale = Vector3.one * BallModel.Size;
            rigid.drag = BallModel.Drag;
        }

        private void Update()
        {
            CheckIfMoving();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Wall"))
            {
                ballHitWall.Raise();
                audioController.PlayHitWallClip();
    }
            if (collision.transform.CompareTag("Ball"))
            {
                ballHitBall.Raise();
                audioController.PlayHitBallClip();
            }
        }

        internal void ApplyForceToBall(Vector3 direction, float velocity)
        {
            rigid.AddForce(direction * velocity, ForceMode.Impulse);
        }

        private void CheckIfMoving()
        {
            if (rigid.velocity.magnitude <= BallModel.MoveThreshHold)
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