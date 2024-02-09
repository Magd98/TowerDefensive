using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{   //Parameters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 40f;
    [SerializeField] ParticleSystem particleToShoot;


    //State of the tower
    Transform targetEnemy;


    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
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

    private void SetTargetEnemy()
    {
        EnemyDamage[] sceneEnemies=FindObjectsOfType<EnemyDamage>();
        if(sceneEnemies.Length == 0 ) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;
        foreach(EnemyDamage testEnemy in sceneEnemies) 
        { 
          closestEnemy=GetClosest(closestEnemy, testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        var distA = Vector3.Distance(transform.position, transformA.position);
        var distB = Vector3.Distance(transform.position, transformB.position);

        if (distA < distB)
        {
            return transformA;
        }

        return transformB;
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
