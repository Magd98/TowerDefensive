using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    void Start()
    {
        
    }

     void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        
        if (hitPoints == 0)
        {
            KillEnemy();
            
        }
    }


    void ProcessHit()
    {
       hitPoints= hitPoints - 1;
       hitParticlePrefab.Play();
    
    }
     void KillEnemy()
    {
        var deathVFX=Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathVFX.Play();
       

        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        Destroy(gameObject);
        
    }
}
