using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    WayPoint wayPoint;

    private void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = wayPoint.GetGridSize();
        Vector3 snapPos = Vector3.zero;
        snapPos.x = wayPoint.GetGridPos().x;
        snapPos.y = 0;
        snapPos.z = wayPoint.GetGridPos().y;
        transform.position = snapPos;
    }

    private void UpdateLabel()
    {
        int gridSize = wayPoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = wayPoint.GetGridPos().x / gridSize + ";" + wayPoint.GetGridPos().y / gridSize;
        gameObject.name = textMesh.text;
    }
}
