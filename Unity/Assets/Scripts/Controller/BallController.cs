using CaromBilliardsGame.Stolzenberg.Events;
using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        internal BallModel BallModel { get { return ballModel; } }

        [Header("Models")]
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
        
        private Vector3 lastFrameVelocity;

        private void Awake()
        {
            sphereCol.radius = BallModel.Size / 2;
            viewTransform.localScale = Vector3.one * BallModel.Size;
            rigid.drag = BallModel.Drag;
        }

        private void Update()
        {
            CheckIfMoving();

            lastFrameVelocity = rigid.velocity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Wall"))
            {
                ballHitWall.Raise();
                if (audioController != null)
                {
                    audioController.PlayHitWallClip(collision.relativeVelocity.magnitude);
                }

                Bounce(collision.contacts[0].normal);
            }
            if (collision.transform.CompareTag("Ball"))
            {
                ballHitBall.Raise();
                if (audioController != null)
                {
                    audioController.PlayHitBallClip(collision.relativeVelocity.magnitude);
                }
            }
        }

        internal void ApplyForceToBall(Vector3 direction, float velocity)
        {
            rigid.AddForce(direction * velocity, ForceMode.Impulse);
        }

        internal void Bounce(Vector3 collisionNormal)
        {
            var newSpeed = lastFrameVelocity.magnitude / 2;
            var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

            rigid.velocity = direction * newSpeed;
        }

        private void CheckIfMoving()
        {
            if (rigid.velocity.magnitude <= BallModel.MoveThreshHold)
            {
                ballModel.IsMoving = false;
            }
            else
            {
                ballModel.IsMoving = true;
            }
        }        
    }
}