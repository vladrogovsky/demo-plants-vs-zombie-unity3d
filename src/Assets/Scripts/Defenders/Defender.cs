using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {
    [SerializeField] int Price = 100;
    ScoreCounter ScoreCounter;
    private void Start()
    {
        ScoreCounter = FindObjectOfType<ScoreCounter>();
    }
    public int returnPrice()
    {
        return Price;
    }
    public void AddStars(int starVal)
    {
        ScoreCounter.ChangeStarts(starVal);
    }
}
