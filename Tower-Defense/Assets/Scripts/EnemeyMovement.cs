using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{

    PathFinder pathfinder;
    
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
            transform.position=point.transform.position;
            yield return new WaitForSeconds(2f);
        }
        print("End Patrolling");

    }
}
