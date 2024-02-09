using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem particleToShoot;

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    void FireAtEnemy()
    {
        float distanceToShoot=Vector3.Distance(targetEnemy.transform.position,gameObject.transform.position);
        if (distanceToShoot <= attackRange) 
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    void Shoot(bool isActive)
    {
        var emissionModule = particleToShoot.emission;
        emissionModule.enabled = isActive;
    }
}
