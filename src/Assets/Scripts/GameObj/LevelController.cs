using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour {
    bool isTimeUp = false;
    int totalNumberOfAttackers = 0;
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject LooseCanvas;
    [SerializeField] float winDelay = 4f;
    AttackerSpawner[] AttackerSpawner;
    bool lose = false;
    // Use this for initialization
	void Start () {
        AttackerSpawner = FindObjectsOfType<AttackerSpawner>();
        WinCanvas.SetActive(false);
        LooseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
	public void timeIsUp()
    {
        isTimeUp = true;
        foreach (var oneSpawner in AttackerSpawner)
        {
            oneSpawner.stopAutoSpawn();
        }
        Debug.Log("auto spawning is off");
    }
    public void addAttacker()
    {
        totalNumberOfAttackers++;
    }
    public void removeAttacker()
    {
        totalNumberOfAttackers--;
        if (totalNumberOfAttackers <= 0 && isTimeUp)
        {
            Debug.Log("Level end");
            if (!lose)
            {
                StartCoroutine(HandleWinCondition());
            }
        }
    }
    public void PlayerLose()
    {
        if (!lose)
        {
            GetComponent<AudioSource>().Play();
            LooseCanvas.SetActive(true);
            lose = true;
            Time.timeScale = 0.1f;
        }

    }
    IEnumerator HandleWinCondition()
    {
        WinCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        GetComponent<LevelLoader>().LoadLevelWithDealay("next", 0);
    }

    // Update is called once per frame
    void Update () {
       

	}
}
