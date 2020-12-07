using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsController : MonoBehaviour {
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.1f;
    MusicPlayerEndless musicPlayer;
    [SerializeField] float defaultDifficulty = 1f;
	// Use this for initialization
	void Start () {
        if (volumeSlider)
        {
            volumeSlider.value = PlayerPrefController.GetMasterVolume();
            volumeSlider.onValueChanged.AddListener(delegate { SetVol(); });
        }
        if (difficultySlider)
        {
            difficultySlider.value = PlayerPrefController.GetMasterDifficulty();
            difficultySlider.onValueChanged.AddListener(delegate { SetDifficulty(); });
        }   
        musicPlayer = FindObjectOfType<MusicPlayerEndless>();
        if (musicPlayer)
            SetVol();
        if (difficultySlider)
            SetDifficulty();
    }

    private void SetVol()
    {
        var newVolume = PlayerPrefController.GetMasterVolume();
        if (volumeSlider)
        {
            newVolume = volumeSlider.value;
            PlayerPrefController.SetMasterVolume(newVolume);
        }
        if (musicPlayer)
        {
            musicPlayer.SetVolume(newVolume);
        }
    }
    private void SetDifficulty()
    {
        var newDifficulty = PlayerPrefController.GetMasterDifficulty();
        if (difficultySlider)
        {
            newDifficulty = difficultySlider.value;
            PlayerPrefController.SetMasterDifficulty(newDifficulty);
        }
    }
    public void ResetToDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
        PlayerPrefController.SetMasterVolume(defaultVolume);
        PlayerPrefController.SetMasterDifficulty(defaultDifficulty);
        if (musicPlayer)
        {
            musicPlayer.SetVolume(defaultVolume);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
