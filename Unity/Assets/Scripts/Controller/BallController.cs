using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private BallModel ballModel;
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;
        [SerializeField] private Rigidbody rigid;
        [SerializeField] private Transform viewTransform;

        private bool moveBall;

        private void Awake()
        {
            sphereCol.radius = ballModel.Size / 2;
            viewTransform.localScale = Vector3.one * ballModel.Size;
            rigid.drag = ballModel.Drag;
            rigid.angularDrag = ballModel.AngularDrag;
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                WallController wallController = collision.gameObject.GetComponent<WallController>();

                Vector3 newDirection = new Vector3();

                switch (wallController.WallModel.MirrorAxis)
                {
                    case WallModel.MirrorAxisEnum.X:
                        newDirection = new Vector3(-collision.relativeVelocity.x, 0, collision.relativeVelocity.z);
                        break;
                    case WallModel.MirrorAxisEnum.Y:
                        newDirection = new Vector3(collision.relativeVelocity.x, 0, -collision.relativeVelocity.z);
                        break;
                }

                rigid.velocity = newDirection / 2;
                print(rigid.velocity);
            }
            if (collision.gameObject.CompareTag("Ball"))
            {
                BallController ballController = collision.gameObject.GetComponent<BallController>();

                Vector3 hitBallDirection = new Vector3(collision.relativeVelocity.x, 0, collision.relativeVelocity.z);
                Vector3 newDirection = new Vector3(-collision.relativeVelocity.x, 0, collision.relativeVelocity.z);

                ballController.ApplyForceToBall(hitBallDirection, collision.relativeVelocity.magnitude / 2);
                rigid.velocity = newDirection / 2;

            }
        }

        internal void ApplyForceToBall(Vector3 direction, float force)
        {
            rigid.AddForce(direction * force);
        }
    }
}