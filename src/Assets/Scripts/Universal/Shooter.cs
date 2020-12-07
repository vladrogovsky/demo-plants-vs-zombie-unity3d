using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
    public void Fire()
    {
        var projectile = Instantiate(projectilePrefab, 
                                    gun.transform.position, 
                                    gun.transform.rotation) as GameObject;
        projectile.transform.parent = gun.transform;
    }
    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] Spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in Spawners)
        {
            bool isCloseEnoughth = (Math.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnoughth)
            {
                myLaneSpawner = spawner; 
            }
        }
    }

    private void Update()
    {
        if (isAttackerInLine())
        {
            animator.SetBool("isAttacking", true);
        } else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool isAttackerInLine()
    {
        if (myLaneSpawner)
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}
