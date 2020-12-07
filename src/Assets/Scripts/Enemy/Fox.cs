using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject DefenderObj = collision.gameObject;
        if (DefenderObj.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("JumpDefender");  
        } else
        {
            Attacker AttackerScript = GetComponent<Attacker>();
            if (DefenderObj.GetComponent<Defender>())
            {
                AttackerScript.Attact(DefenderObj);
            }
            
        }
    }
}
