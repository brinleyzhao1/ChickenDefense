using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    [HideInInspector]
    public bool isExplored = false;
    [HideInInspector] public Waypoint exploredFrom;

    // public bool isPlaceable = true;

    Vector2Int gridPos;

    const int gridSize = 2;
    const string towerParentName = "Towers";

    [SerializeField] private Orientation _orientation;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    public Orientation GetOrientation()
    {
      return _orientation;
    }

    // void OnMouseOver()
    // {
    //     if (Input.GetMouseButtonDown(0)) // left click
    //     {
    //         print("way point clicked");
    //         // if (isPlaceable)
    //         // {
    //         //     FindObjectOfType<TowerFactory>().AddTower(this);
    //         // }
    //         // else
    //         // {
    //         //     print("Can't place here");
    //         // }
    //     }
    // }
}
