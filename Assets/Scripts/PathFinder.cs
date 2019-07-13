using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();

    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint wayPoint in wayPoints)
        {
            if (grid.ContainsKey(wayPoint.GetGridPos()))
            {
                Debug.Log("Overllapping blocks at: " + wayPoint.GetGridPos());
            }
            else
            {
                grid.Add(wayPoint.GetGridPos(), wayPoint);
            }
        }
    }

    void Update()
    {

    }
}
