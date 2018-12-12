using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu(menuName = "Models/Ball")]
    public class BallModel : ScriptableObject
    {
        public BallTypeEnum BallType { get { return ballType; } }
        public float Size { get { return size; } }
        public float Drag { get { return drag; } }
        public float MoveThreshHold { get { return moveThreshHold; } }
        public bool IsMoving { get; internal set; }

        [SerializeField] private BallTypeEnum ballType;
        [SerializeField] private float size;
        [SerializeField] private float drag;
        [SerializeField] private float moveThreshHold;

        
        public enum BallTypeEnum { White, Red, Yellow }
    }
}
