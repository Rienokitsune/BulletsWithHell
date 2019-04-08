using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//regular path type. PathData is interpreted as a bezier curves for the purpose of moving objects along it;

public class PathAsset : PathSystem
{
    public void SetPath(PathData data)
    {
        points = data;
    }

    public PathData GetPath() { return points; }
}
