using System;
using UnityEngine;
using UnityEngine.Audio;

namespace CaromBilliardsGame.Stolzenberg.Models
{
    [CreateAssetMenu(menuName = "Models/Audio")]
    public class AudioModel : ScriptableObject
    {
        public AudioClass SwingQueueClip;
        public AudioClass HitWallClip;
        public AudioClass HitBallClip;
        public AudioClass EarnPointClip;
        public AudioClass WinClip;
    }

    [Serializable]
    public class AudioClass
    {
        public AudioClip AudioClip;
        public AudioMixerGroup AudioMixerGroup;
    }
}
