using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CaromBilliardsGame.Stolzenberg.Controllers
{
    public class SettingsController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Slider musicSlider;

        private void Awake()
        {
            

            SetSoundVolume(soundSlider.value);
            SetMusicVolume(musicSlider.value);
        }

        public void SetSoundVolume(float volume)
        {
            audioMixer.SetFloat("SoundVolume", volume);
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("MusicVolume", volume);
        }
    }

}