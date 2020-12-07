using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerEndless : MonoBehaviour {
    AudioSource AudioSource;
    PlayerPrefController PlayerPrefController;
    // Use this for initialization
    private void Awake()
    {
        if (FindObjectsOfType<MusicPlayerEndless>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start () {
            AudioSource = gameObject.GetComponent<AudioSource>();
            PlayerPrefController = FindObjectOfType<PlayerPrefController>();
            AudioSource.volume = PlayerPrefController.GetMasterVolume();
    }
	public void SetVolume(float newVol)
    {
            AudioSource.volume = newVol;
    }
}
