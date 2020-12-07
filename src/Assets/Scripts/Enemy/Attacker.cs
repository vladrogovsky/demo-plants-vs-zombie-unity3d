using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [Range(0f,5f)]
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float damage = 20;
    [SerializeField] int demageToPlayerLifes = -20;
    GameObject currentTarget;
    Animator selfAnimator;
    HealthControl DefenderHealth;
    LevelController LevelController;
    private void OnDestroy()
    {
        LevelController.removeAttacker();
    }
    public void Start()
    {
        LevelController = FindObjectOfType<LevelController>();
        selfAnimator = GetComponent<Animator>();
    }
    public int DemageToPlayer()
    {
        return demageToPlayerLifes;
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    public void Attact (GameObject target)
    {
        if (target)
        {
            selfAnimator.SetBool("isAttacking", true);
            currentTarget = target;
        }
    }
    public void StrikeCurreentTarger()
    {
        if (!currentTarget) {
            currentTarget = null;
            selfAnimator.SetBool("isAttacking", false);
            return;
        }
        DefenderHealth = currentTarget.GetComponent<HealthControl>();
        if (DefenderHealth)
        {
            DefenderHealth.DealDamage(damage);
            if (DefenderHealth.GetCurHealth()<=0)
            {
                currentTarget = null;
                selfAnimator.SetBool("isAttacking", false);
            }
        }

    }
    void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
	}
}
