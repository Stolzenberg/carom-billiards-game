using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class BallController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private BallModel ballModel;
        [Header("Components")]
        [SerializeField] private SphereCollider sphereCol;

        private void Awake()
        {
            sphereCol.radius = ballModel.Size / 2;
        }

        private void OnCollisionEnter(Collision collision)
        {
            
        }
    }
}
