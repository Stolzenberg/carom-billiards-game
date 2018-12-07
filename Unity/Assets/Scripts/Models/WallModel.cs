using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu]
    public class WallModel : ScriptableObject
    {
        public MirrorAxisEnum MirrorAxis;
        public enum MirrorAxisEnum { X, Y }
    }
}
