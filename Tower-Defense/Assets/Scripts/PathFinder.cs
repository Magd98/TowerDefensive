using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> levelGrid= new Dictionary<Vector2Int,Waypoint>();
    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right,
    };

       void Start()
    {
        LoadBlocks();
        HighlightStartandEnd();
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        foreach(Vector2Int direction in directions)
        {
            print(direction);
        }
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints) 
        {
            if (levelGrid.ContainsKey(waypoint.GetGridPos()))
            {

                Debug.LogWarning("Skipping the overlapping block at: " + waypoint);
            }
            else
            {
                levelGrid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
        print(levelGrid.Count) ;
    }

    void HighlightStartandEnd() 
    {
            startWaypoint.SetColor(Color.green);
            endWaypoint.SetColor(Color.red);
     
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
