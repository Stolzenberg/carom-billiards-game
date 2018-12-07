using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    [RequireComponent(typeof(BoxCollider))]
    public class WallController : MonoBehaviour
    {
        public WallModel WallModel { get { return wallModel; } }

        [Header("Model")]
        [SerializeField] private WallModel wallModel;
    }
}
