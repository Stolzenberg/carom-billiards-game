using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu]
    public class BallModel : ScriptableObject
    {
        public float Size;
        public float Mass;
        public float Drag;
        public float AngularDrag;
    }
}
