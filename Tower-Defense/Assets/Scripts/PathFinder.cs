using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int,Waypoint> levelGrid= new Dictionary<Vector2Int,Waypoint>();

    Queue<Waypoint> queueWay =new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; // todo make private.

    List<Waypoint> path= new List<Waypoint>();

    Waypoint searchCenter;

    [SerializeField] Waypoint startWaypoint;
    [SerializeField] Waypoint endWaypoint;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right,
    };

    
    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        HighlightStartandEnd();
        BreadthFirstSearch();
        CreatePath();
    }


     void CreatePath()
    {
        path.Add(endWaypoint);
        Waypoint previous = endWaypoint.exploredFrom;
        while (previous != startWaypoint) 
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
    }

    void BreadthFirstSearch()
    {
        queueWay.Enqueue(startWaypoint);
        while (queueWay.Count > 0&& isRunning)
        {
            searchCenter = queueWay.Dequeue();
            HaltingIfEndFound();
            ExploreNeighbors();
            searchCenter.isExplored = true;

        }
        print("Finished Pathfinding ?");
    }

     void HaltingIfEndFound()
    {
        if (searchCenter == endWaypoint)
        {
            
            isRunning = false;
        }


    }

    void ExploreNeighbors()
    {
        if(!isRunning) { return;}

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            try 
            {
                
                QueuingNewNeighbors(neighborCoordinates);

                }
            catch
            {

            }

        }
    }

    void QueuingNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = levelGrid[neighborCoordinates];
        if (neighbor.isExplored || queueWay.Contains(neighbor)) 
        {
            //do nothing
        }
        else
        {
            queueWay.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
            
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
