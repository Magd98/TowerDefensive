using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> LevelGrid= new Dictionary<Vector2Int,Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
    }

    void LoadBlocks()
    {
         var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints) 
        { 
            LevelGrid.Add(waypoint.GetGridPos(), waypoint);
        }
        print(LevelGrid.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
