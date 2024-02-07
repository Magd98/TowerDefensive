using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
   
    void Start()
    {
        
    }

     void OnParticleCollision(GameObject other)
    {
        print ("I'm Hit");
    }
}
