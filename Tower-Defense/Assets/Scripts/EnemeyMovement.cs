using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{

    PathFinder pathfinder;
    [SerializeField] float movementSpeed = 0.5f;
    [SerializeField] ParticleSystem goalVfx;
    void Start()
    {
        pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    

    IEnumerator FollowPath(List<Waypoint>path)
    {
        print("Start Patrolling .....");
        foreach (Waypoint point in path)
        {
            transform.position = point.transform.position;
            yield return new WaitForSeconds(movementSpeed);
        }
        SelfDestruct();
        print("End Patrolling");

    }

    private void SelfDestruct()
    {
        var gVfx = Instantiate(goalVfx, transform.position, Quaternion.identity);
        gVfx.Play();
        Destroy(gVfx, gVfx.main.duration);
        Destroy(gameObject);
    }
}
