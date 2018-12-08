using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu]
    public class BallModel : ScriptableObject
    {
        public BallTypeEnum BallType;
        public float Size;
        public float Drag;
        public float MoveThreshHold;

        public enum BallTypeEnum { White, Red, Yellow }
    }
}
