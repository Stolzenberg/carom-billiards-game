using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private AudioModel audioModel;

        public void PlaySwingQueueClip(float pressedTime)
        {
            float soundVolume = pressedTime;
            CreateAudioSourceObj(audioModel.SwingQueueClip, soundVolume);
        }

        public void PlayHitWallClip(float hitVelocity)
        {
            float soundVolume = hitVelocity / 50;
            CreateAudioSourceObj(audioModel.HitWallClip, soundVolume);
        }

        public void PlayHitBallClip(float hitVelocity)
        {
            float soundVolume = hitVelocity / 50;
            CreateAudioSourceObj(audioModel.HitBallClip, soundVolume);
        }

        private void CreateAudioSourceObj(AudioClip audioClip, float volume)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "AudioSource";
            gameObj.transform.position = transform.position;

            AudioSource audioSource = gameObj.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.maxDistance = 1.0f;
            audioSource.volume = volume;

            audioSource.Play();
            Destroy(gameObj, audioSource.clip.length);
        }
    }
}
