using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIOptions : MonoBehaviour
{
    public AudioMixer mainAudioMixer;

    [Header("Volume Sliders")]
    public Slider mainVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    private void Start()
    {
        //defaults for slider position
        mainVolumeSlider.value = 1.0f;
        musicVolumeSlider.value = 1.0f;
        soundVolumeSlider.value = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
            GameManager.instance.ActivateMainMenuState();
        }
    }

    //opens main menu
    public void MainMenuButton()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        GameManager.instance.ActivateMainMenuState();
    }

    public void OnMainVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        VolumeChange(mainAudioMixer, "MasterVolume", mainVolumeSlider);
    }

    public void OnMusicVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        VolumeChange(mainAudioMixer, "MusicVolume", musicVolumeSlider);
    }

    public void OnSoundVolumeChange()
    {
        AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.menuButton);
        VolumeChange(mainAudioMixer, "SoundVolume", soundVolumeSlider);
    }

    public void VolumeChange(AudioMixer audioMixer, string nameOfMixer, Slider volumeSlider)
    {
        float newVolume = volumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80; //set to bottommost log value for db
        }
        else
        {
            //>0 so use log10 because decibals
            newVolume = Mathf.Log10(newVolume);

            //0-20db instead of 0-1
            newVolume = newVolume * 20;

        }

        audioMixer.SetFloat(nameOfMixer, newVolume);
    }
}
