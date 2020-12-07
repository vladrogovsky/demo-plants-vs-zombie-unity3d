using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            GetComponent<Animator>().SetBool("isUnderAttack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            GetComponent<Animator>().SetBool("isUnderAttack", false);
        }
    }
}
