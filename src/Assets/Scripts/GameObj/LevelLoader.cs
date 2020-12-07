using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
    [SerializeField] bool Autoload = false;
    [SerializeField] string level = "next";
    [SerializeField] int delayInSeconds;
    private void Start()
    {
       if (Autoload)
        { 
            LoadLevelWithDealay(level, delayInSeconds);
        }
    }
    public void RealodLevel()
    {
        int levelToLoad = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelToLoad);
    }
    public void LevelLoad(string level)
    {
        if (level == "next" || level.Trim() == "")
        {
            int levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            SceneManager.LoadScene(level);
        }
    }
    public void LoadLevelWithDealay(string level="next", int delayInSeconds=0)
    {
        if (delayInSeconds > 0)
        {
            StartCoroutine(DelayLoad(level, delayInSeconds));
        }
        else
        {
            LevelLoad(level);
        }
}
    private IEnumerator DelayLoad(string level, int delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        LevelLoad(level);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
