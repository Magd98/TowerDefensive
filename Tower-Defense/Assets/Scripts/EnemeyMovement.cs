using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        print("Start Patrolling .....");
        foreach (Waypoint point in path)
        {
            transform.position=point.transform.position;
            print("Visiting: " + point.name);
            yield return new WaitForSeconds(1f);
        }
        print("End Patrolling");

    }
}
