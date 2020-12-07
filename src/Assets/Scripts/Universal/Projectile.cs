using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileDemage = 100f;
    // Use this for initialization
    void Start () {
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var AttackerComp = collision.gameObject.GetComponentInParent<Attacker>();
        if (AttackerComp)
        {
            var HealthComp = collision.gameObject.GetComponentInParent<HealthControl>();
            if (HealthComp)
            {
                HealthComp.DealDamage(projectileDemage);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left*Time.deltaTime*projectileSpeed); //reason for Vector2.left - sprites ScaleX = -1
    }
}
