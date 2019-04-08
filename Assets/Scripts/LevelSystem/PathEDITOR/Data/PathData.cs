using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


//this class holds data for paths and is universal for all types of paths


[System.Serializable]
public class PathData
{
    [SerializeField][ReadOnly]
    public List<Vector2> waypoints;

    public PathData(List<Vector2> points)
    {
        waypoints = points;
    }

    public Vector2 this[int i]
    {
        get
        {
            return waypoints[i];
        }
    }
     

}
