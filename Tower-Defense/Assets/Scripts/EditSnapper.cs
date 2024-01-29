using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditSnapper : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)] float gridSize = 10f;
    void Update()
    {
        Vector3 snapPos=transform.position;
        snapPos.x=Mathf.RoundToInt(snapPos.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(snapPos.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f ,snapPos.z);



    }
}
