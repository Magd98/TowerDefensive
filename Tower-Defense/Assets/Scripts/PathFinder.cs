using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> levelGrid= new Dictionary<Vector2Int,Waypoint>();

    Queue<Waypoint> queueWay =new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo make private.

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
        Pathfinding();
    }

     void Pathfinding()
    {
        queueWay.Enqueue(startWaypoint);
        while (queueWay.Count > 0&& isRunning)
        {
            Waypoint searchCenter = queueWay.Dequeue();
            print("Searching From: " + searchCenter);
            HaltingIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
            searchCenter.isExplored = true;

        }
        print("Finished Pathfinding ?");
    }

     void HaltingIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("We Found our way there");
            isRunning = false;
        }


    }

    void ExploreNeighbors(Waypoint from)
    {
        if(!isRunning) { return;}

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            try
            {
                QueuingNewNeighbors(neighborCoordinates);
            }

            catch
            {
                //do nothing
            }
        }
    }

    void QueuingNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = levelGrid[neighborCoordinates];
        if (neighbor.isExplored) 
        {
            //do nothing
        }
        else
        {
            neighbor.SetColor(Color.black);
            queueWay.Enqueue(neighbor);
            print("Queuing: " + neighbor);
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
