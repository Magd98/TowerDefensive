using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue= new Queue<Tower>();    

   

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimit)
        {
            InsantiateNewTower(baseWaypoint);
        }

        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InsantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower=Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
       
       
    }

    void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower=towerQueue.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint=newBaseWaypoint;
        oldTower.transform.position= newBaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
        
    }
}
