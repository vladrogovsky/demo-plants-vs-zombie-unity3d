using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLives : MonoBehaviour {
    [SerializeField] float baseLives = 100;
    int currentLives;
    LevelLoader LevelLoaderObj;
    Text LivesLabel;
    LevelController LevelController;
    bool alredyLose = false;
    private void Start()
    {
        currentLives = (int)Mathf.Round(baseLives / PlayerPrefController.GetMasterDifficulty());
        LevelLoaderObj = FindObjectOfType<LevelLoader>();
        LivesLabel = GetComponent<Text>();
        LivesLabel.text = currentLives.ToString();
        LevelController = FindObjectOfType<LevelController>();
    }
    public void ChangeLifes(int changeValue)
    {
        if (!alredyLose)
        {
            currentLives += changeValue;
            if (currentLives <= 0)
            {
                LevelController.PlayerLose();
                LivesLabel.text = ":(";
                alredyLose = true;
            }
            else
            {
                LivesLabel.text = currentLives.ToString();
            }
        }

    }
}
