using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//displays all paths in a bundle, Has custom editor script that handles drawing the paths

[ExecuteInEditMode]
public class PathViewer : MonoBehaviour
{
    [SerializeField][AssetList] public PathSystem path;
    List<Vector2> points;

    private void Start()
    {
        LoadPath();
    }

    [Button]
    private void LoadPath()
    {
        points = path.points.waypoints;
    }


    private void OnDrawGizmos()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawSphere(points[i],0.1f);
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }

}
