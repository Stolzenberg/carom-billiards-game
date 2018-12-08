using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu]
    public class AIModel : ScriptableObject
    {
        [Range(0.0f, 100.0f)] public float Inaccuracy;
        public float Force;
    }
}
