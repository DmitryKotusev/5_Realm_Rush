using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoint startWayPoint, endWayPoint;

    Dictionary<Vector2Int, WayPoint> grid;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if (grid == null)
        {
            LoadBlocks();
        }
        return PathFind();
    }

    private List<WayPoint> PathFind()
    {
        if (startWayPoint.GetGridPos() == endWayPoint.GetGridPos())
        {
            Debug.Log("Start point is equal to end.");
            return new List<WayPoint>();
        }

        Dictionary<Vector2Int, Vector2Int> visitedPoints = new Dictionary<Vector2Int, Vector2Int>();
        Queue<WayPoint> queue = new Queue<WayPoint>();
        queue.Enqueue(startWayPoint);
        visitedPoints.Add(startWayPoint.GetGridPos(), startWayPoint.GetGridPos());

        while (queue.Count > 0)
        {
            var currentPoint = queue.Dequeue();
            if (currentPoint.GetGridPos() == endWayPoint.GetGridPos())
            {
                break;
            }
            ExploreNeighbors(currentPoint, visitedPoints, queue);
        }

        return GeneratePath(visitedPoints);
    }

    private List<WayPoint> GeneratePath(Dictionary<Vector2Int, Vector2Int> visitedPoints)
    {
        List<WayPoint> resultList = new List<WayPoint>();
        resultList.Add(endWayPoint);
        var currentPoint = grid[visitedPoints[endWayPoint.GetGridPos()]];
        while (currentPoint.GetGridPos() != startWayPoint.GetGridPos())
        {
            resultList.Add(currentPoint);
            currentPoint = grid[visitedPoints[currentPoint.GetGridPos()]];
        }
        resultList.Add(startWayPoint);

        resultList.Reverse();

        return resultList;
    }

    private void ExploreNeighbors(WayPoint wayPoint, Dictionary<Vector2Int, Vector2Int> visitedPoints,
        Queue<WayPoint> queue)
    {
        foreach (Vector2Int direction in directions)
        {
            QueueNewNeighbor(wayPoint, direction, visitedPoints, queue);
        }
    }

    private void QueueNewNeighbor(WayPoint wayPoint, Vector2Int direction,
        Dictionary<Vector2Int, Vector2Int> visitedPoints, Queue<WayPoint> queue)
    {
        if (grid.ContainsKey(wayPoint.GetGridPos() + direction))
        {
            var neighbor = grid[wayPoint.GetGridPos() + direction];
            if (!visitedPoints.ContainsKey(neighbor.GetGridPos()))
            {
                visitedPoints.Add(neighbor.GetGridPos(), wayPoint.GetGridPos());
                queue.Enqueue(neighbor);
            }
        }
    }

    private void LoadBlocks()
    {
        grid = new Dictionary<Vector2Int, WayPoint>();
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
