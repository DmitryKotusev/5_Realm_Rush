using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField]
    int towerLimit = 5;

    [SerializeField]
    Transform parentTransform;

    [SerializeField]
    GameObject towerPrefab;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(WayPoint wayPointBase)
    {
        if (towers.Count >= towerLimit)
        {
            RemoveOldestTower(wayPointBase);
        }
        else
        {
            AddNewTower(wayPointBase);
        }
    }

    private void RemoveOldestTower(WayPoint wayPointBase)
    {
        Tower oldestTower = towers.Dequeue();
        oldestTower.GetPlacementCoordinate().isPlaceble = true;
        oldestTower.SetPlacementCoordinate(wayPointBase);
        wayPointBase.isPlaceble = false;
        oldestTower.transform.position = wayPointBase.transform.position;
        towers.Enqueue(oldestTower);
    }

    private void AddNewTower(WayPoint wayPointBase)
    {
        GameObject towerInstance = Instantiate(towerPrefab, wayPointBase.transform.position, Quaternion.identity, parentTransform);
        towerInstance.GetComponent<Tower>().SetPlacementCoordinate(wayPointBase);
        wayPointBase.isPlaceble = false;
        towers.Enqueue(towerInstance.GetComponent<Tower>());
    }
}
