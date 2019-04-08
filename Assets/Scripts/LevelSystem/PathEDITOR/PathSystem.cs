using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

//Abstract classs of Pathing system, right now it only holds data. need to move code from pathData here;

public abstract class PathSystem : ScriptableObject
{
    [SerializeField,ReadOnly]public PathData points;
}
