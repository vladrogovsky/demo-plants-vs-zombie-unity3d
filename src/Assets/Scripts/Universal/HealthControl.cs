using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour {
    [SerializeField] float Health = 100f;
    [SerializeField] GameObject ParticleEffectPrefab;
    // Use this for initialization
    void Start () {
		
	}
	public void DealDamage(float DamageVal)
    {
        Health -= DamageVal;
        if (Health <= 0)
        {
            KillObject();
        }
    }
    public float GetCurHealth()
    {
        return Health;
    }
    private void KillObject()
    {
        if (ParticleEffectPrefab)
        {
            var DeathVFX = Instantiate(ParticleEffectPrefab, transform.position, transform.rotation) as GameObject;
            DeathVFX.transform.parent = transform.parent;
            Destroy(DeathVFX, 1f);
        }
        Destroy(gameObject);
    }
}
