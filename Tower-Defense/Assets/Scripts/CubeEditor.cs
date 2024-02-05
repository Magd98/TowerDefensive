using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();    
    }


    void Update()
    {
        SnapToGrid();
        UpdateLabel();



    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();


        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            0f,
            waypoint.GetGridPos().y * gridSize
            );
    }

     void UpdateLabel()
    {
       

        TextMesh label = GetComponentInChildren<TextMesh>();
        label.text = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        gameObject.name = label.text;

    }
}

