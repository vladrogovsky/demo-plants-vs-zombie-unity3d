using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {
    Attacker AttackerScript;
    private void Start()
    {
        AttackerScript = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            AttackerScript.Attact(otherObject);
        }
    }
}
