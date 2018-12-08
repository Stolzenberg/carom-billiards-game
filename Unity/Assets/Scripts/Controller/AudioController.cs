using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [Header("Model")]
        [SerializeField] private AudioModel audioModel;

        public void PlaySwingQueueClip()
        {
            CreateAudioSourceObj(audioModel.SwingQueueClip);
        }

        public void PlayHitWallClip()
        {
            CreateAudioSourceObj(audioModel.HitWallClip);
        }

        public void PlayHitBallClip()
        {
            CreateAudioSourceObj(audioModel.HitBallClip);
        }

        private void CreateAudioSourceObj(AudioClip audioClip)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "AudioSource";
            gameObj.transform.position = transform.position;

            AudioSource audioSource = gameObj.AddComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            audioSource.maxDistance = 1.0f;

            Destroy(gameObj, audioSource.clip.length);
        }
    }
}
