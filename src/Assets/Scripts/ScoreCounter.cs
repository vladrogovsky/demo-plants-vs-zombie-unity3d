using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour {
    [SerializeField] int starScore = 100;
    Text scoreText;
	void Start () {
        scoreText = GetComponent<Text>();
        updateScoreText();
    }
	private void updateScoreText()
    {
        scoreText.text = starScore.ToString();
    }
	public void ChangeStarts(int starAmout)
    {
        if (starScore + starAmout >= 0)
        {
            starScore += starAmout;
            updateScoreText();
        }
    }
    public int GetScore()
    {
        return starScore;
    }
	void Update () {
		
	}
}
