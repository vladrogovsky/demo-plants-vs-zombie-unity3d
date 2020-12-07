using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderBTNS : MonoBehaviour {
    [SerializeField] Defender DefenderPrefab;
    DefenderSpawner DefenderSpawner;
    [SerializeField] Color unAvalibleColor = new Color(0, 0, 0);
    [SerializeField] Color avalibleColor = new Color(1, 1, 1);
    [SerializeField] Color activeColor = new Color(1, 1, 1);
    [SerializeField] Color hoverColor = new Color(1, 1, 1); 
    SpriteRenderer ButtonSprite;
    DefenderBTNS[] AllButtons;
    [SerializeField] bool selected = false;
    [SerializeField] bool avalible = false;
    ScoreCounter ScoreCounter;
    int defenderCost = 100;
    int currentPoint = 100;
    public Color ColorChoose(bool hover=false)
    {
        Color returnColor = unAvalibleColor;
        if (avalible)
        {
            if (selected)
            {
                returnColor = activeColor;
            } else if (hover)
            {
                returnColor = hoverColor;
            }
            else {
                returnColor = avalibleColor;
            }
        } else
        {
            returnColor = unAvalibleColor;
        }
        return returnColor;
    }
    private void OnMouseEnter()
    {
        if (avalible) ButtonSprite.color = ColorChoose(true);
    }
    private void OnMouseExit()
    {
        if (avalible) ButtonSprite.color = ColorChoose();
    }
    private void OnMouseDown()
    {
        if (avalible)
        {
            if (!selected)
            {
                DefenderSpawner.SetDefender(DefenderPrefab);
                selected = true;
            }
            else
            {
                DefenderSpawner.SetDefender(null);
                selected = false;
            }
            ButtonSprite.color = ColorChoose();
        }

    }
    void Start () {
        ScoreCounter = FindObjectOfType<ScoreCounter>();
        currentPoint = ScoreCounter.GetScore();
        defenderCost = DefenderPrefab.returnPrice();
        ButtonSprite = GetComponent<SpriteRenderer>();
        AllButtons = FindObjectsOfType<DefenderBTNS>();
        DefenderSpawner = FindObjectOfType<DefenderSpawner>();
    }
	
    private void ResetAllBtns()
    {
        foreach (var oneBtn in AllButtons)
        {
            oneBtn.ResetColor();
        }
    }
    public void ResetColor()
    {
        ButtonSprite.color = ColorChoose();
    }

    void Update () {
        currentPoint = ScoreCounter.GetScore();
        if (defenderCost <= currentPoint)
        {
            avalible = true;
            ResetAllBtns();
            ButtonSprite.color = ColorChoose();
        }
        else
        {
            DefenderSpawner.SetDefender(null);
            selected = false;
            avalible = false;
            ResetAllBtns();
            ButtonSprite.color = ColorChoose();
        }

    }
}
