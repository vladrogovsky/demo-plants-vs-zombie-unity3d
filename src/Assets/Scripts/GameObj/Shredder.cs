using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {
    PlayerLives PlayerLivesObj;
    private void Start()
    {
        PlayerLivesObj = FindObjectOfType<PlayerLives>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attacker>() != null)
        {
            int demageToPlayer = collision.gameObject.GetComponent<Attacker>().DemageToPlayer();
            if (gameObject.name == "ShredderLeft" && Mathf.Abs(demageToPlayer) > 0)
            {
                PlayerLivesObj.ChangeLifes(demageToPlayer);
            }
            Destroy(collision.gameObject);
        }
    }
}
