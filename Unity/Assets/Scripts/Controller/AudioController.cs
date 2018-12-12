using CaromBilliardsGame.Stolzenberg.Models;
using UnityEngine;
using UnityEngine.Audio;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class AudioController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private AudioMixer audioMixer;
        [Header("Models")]
        [SerializeField] private AudioModel audioModel;

        internal void PlaySwingQueueClip(float pressedTime)
        {
            float soundVolume = pressedTime;
            CreateAudioSourceObj(audioModel.SwingQueueClip, soundVolume);
        }

        internal void PlayHitWallClip(float hitVelocity)
        {
            float soundVolume = hitVelocity / 50;
            CreateAudioSourceObj(audioModel.HitWallClip, soundVolume);
        }

        internal void PlayHitBallClip(float hitVelocity)
        {
            float soundVolume = hitVelocity / 50;
            CreateAudioSourceObj(audioModel.HitBallClip, soundVolume);
        }

        internal void PlayerEarnPointClip()
        {
            CreateAudioSourceObj(audioModel.EarnPointClip, 1.0f);
        }

        internal void GameOverSoundClip()
        {
            CreateAudioSourceObj(audioModel.WinClip, 1.0f);
        }

        private void CreateAudioSourceObj(AudioClass audioClass, float volume)
        {
            GameObject gameObj = new GameObject();
            gameObj.name = "AudioSource";
            gameObj.transform.position = transform.position;

            AudioSource audioSource = gameObj.AddComponent<AudioSource>();
            audioSource.clip = audioClass.AudioClip;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = audioClass.AudioMixerGroup;

            audioSource.Play();
            Destroy(gameObj, audioSource.clip.length);
        }       
    }
}
