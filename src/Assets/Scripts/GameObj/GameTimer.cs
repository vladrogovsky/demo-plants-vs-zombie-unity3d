using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour {
    [SerializeField] float levelTimeinSeconds = 10f;
    bool levelEnded = false;
    AttackerSpawner[] AttackerSpawner;
    Slider Slider;
    LevelController LevelController;
    // Use this for initialization
    void Start () {
        Slider = gameObject.GetComponent<Slider>();
        LevelController = FindObjectOfType<LevelController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!levelEnded)
        {
            Slider.value = Time.timeSinceLevelLoad / levelTimeinSeconds;
            bool timerFinished = (Time.timeSinceLevelLoad >= levelTimeinSeconds);
            if (timerFinished && !levelEnded)
            {
                Debug.Log("Time is up");
                LevelController.timeIsUp();
                levelEnded = true;
            }
        }
	}
}
