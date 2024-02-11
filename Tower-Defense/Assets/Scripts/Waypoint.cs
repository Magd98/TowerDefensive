using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    const int gridSize = 10;

    [SerializeField] Tower towerPrefab;
    public bool isPlaceable = true;

    public bool isExplored=false;
    public Waypoint exploredFrom;

    public int GetGridSize()
    {
        return gridSize;
    }
     
    
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize) ,
             Mathf.RoundToInt(transform.position.z / gridSize)
             );

    }

    private void OnMouseOver()
    {
        print(gameObject.name);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                Instantiate(towerPrefab,transform.position,Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Can't Place here");
            }
        }
        
           
        
    }
}
