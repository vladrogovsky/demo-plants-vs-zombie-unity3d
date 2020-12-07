using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {
    Defender DefenderPrefab;
    ScoreCounter ScoreCounter;
    private void Start()
    {
        ScoreCounter = FindObjectOfType<ScoreCounter>();
    }
    void OnMouseDown()
    {
        SpawnDefender(DefenderPrefab, GetClickSquer());
    }
    public void SetDefender(Defender Defender)
    {
        DefenderPrefab = Defender;
    }
    private Vector2 GetClickSquer()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return SnapToGrid(worldPos);
    }
    private Vector2 SnapToGrid(Vector2 rawPos)
    {
        int newX = Mathf.RoundToInt(rawPos.x);
        int newY = Mathf.RoundToInt(rawPos.y);
        return new Vector2(newX, newY);
    }
    private void SpawnDefender(Defender DefenderPrefab,Vector2 position)
    {
        if (DefenderPrefab)
        {
            var defenderCost = DefenderPrefab.returnPrice();
            var currentScore = ScoreCounter.GetScore();
            if (defenderCost <= currentScore)
            {
                /*Defender Defender = */Instantiate(DefenderPrefab,
                                                position,
                                                Quaternion.identity)/* as Defender*/;
                ScoreCounter.ChangeStarts(defenderCost * -1);
            }
        }
    }
}
