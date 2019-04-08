using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//Monobehaviour part of Path Editing Tool. it holds instance of PathData and holds PathBundle to use as a name prefix for created paths
//

[ExecuteInEditMode]
public class PathCreator : MonoBehaviour
{
    [SerializeField] public PathBundle bundle;
    [HideInInspector]public RawPathData pathData;
    [SerializeField] bool drawingGizmos;
    [ReadOnly] public List<Vector2> points;
    

    public RawPathData createPath()
    {
         pathData = new RawPathData(transform.position);
        
        //points = pathData.GetPath();
        return pathData;
        
    }

    private void Update()
    {
        points = pathData.waypoints;
    }

    public void DeletePath()
    {
        pathData = null;
    }

    
    private void OnDrawGizmos()
    {
        
        if (drawingGizmos)
        {
            for (int i = 0; i < pathData.NumOfPoints; i++)
            {
            Gizmos.color = Color.white;
                Gizmos.DrawLine(pathData[i], pathData[i+1]);
                
            Gizmos.DrawSphere(pathData[i], 0.1f);
            
            }

        }
        
    }
}
