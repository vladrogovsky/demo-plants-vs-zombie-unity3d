using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefController : MonoBehaviour {
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
/* Todo: -add cost for defenders, tune gameplay
 * Todo: add levels
 */
    MusicPlayerEndless MusicPlayerEndless;
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 1f;
    const float MAX_DIFFICULTY = 4f;
    private void Start()
    {
        MusicPlayerEndless = FindObjectOfType<MusicPlayerEndless>();
    }
    public static void SetMasterVolume(float newVol)
    {
        if (newVol >= MIN_VOLUME && newVol <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, newVol);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
    public static void SetMasterDifficulty(float newDifficulty)
    {
        if( newDifficulty<=MAX_DIFFICULTY && newDifficulty >= MIN_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, newDifficulty);
        }
        else
        {
            Debug.LogError("Master difficulty out of range");
        }
    }
    public static float GetMasterDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
