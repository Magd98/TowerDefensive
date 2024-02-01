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
            waypoint.GetGridPos().x,
            0f,
            waypoint.GetGridPos().y
            );
    }

     void UpdateLabel()
    {
        int gridSize=waypoint.GetGridSize();

        TextMesh label = GetComponentInChildren<TextMesh>();
        label.text = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
        gameObject.name = label.text;

    }
}

