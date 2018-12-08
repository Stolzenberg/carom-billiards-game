using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu]
    public class AudioModel : ScriptableObject
    {
        public AudioClip SwingQueueClip;
        public AudioClip HitWallClip;
        public AudioClip HitBallClip;
    }
}
