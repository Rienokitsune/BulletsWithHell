using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class RawPathData {

    [SerializeField]
    [ReadOnly]

    public List<Vector2> waypoints;

    public RawPathData(Vector2 center)
    {
        waypoints = new List<Vector2>
        {
            center+Vector2.left,
            center+(Vector2.left+Vector2.up)*0.5f,
            center+(Vector2.right+Vector2.down)*0.5f,
            center+ Vector2.right
        };
    }

    public void AddSegment(Vector2 Anchor)
    {
        waypoints.Add(waypoints[waypoints.Count - 1] * 2 - waypoints[waypoints.Count - 2]);
        waypoints.Add((waypoints[waypoints.Count - 1] + Anchor) * 0.5f);
        waypoints.Add(Anchor);
    }

    public Vector2 this[int i]
    {
        get
        {
            return waypoints[i];
        }
    }

    public int NumOfPoints
    {
        get
        {
            return waypoints.Count;
        }
    }

    public int NumOfSegments
    {
        get
        {
            return (waypoints.Count - 4) / 3 + 1;
        }
    }

    public Vector2[] GetPointsInSegment(int i)
    {
        return new Vector2[] { waypoints[i * 3], waypoints[i * 3 + 1], waypoints[i * 3 + 2], waypoints[i * 3 + 3] };
    }

    public void MovePoint(int i, Vector2 pos)
    {
        Vector2 deltaMove = pos - waypoints[i];
        waypoints[i] = pos;

        if (i % 3 == 0)
        {
            if (i + 1 < waypoints.Count)
            {
                waypoints[i + 1] += deltaMove;
            }
            if (i - 1 >= 0)
            {
                waypoints[i - 1] += deltaMove;
            }
        }
        else
        {
            bool nextPointIsAnchor = (i + 1) % 3 == 0;
            int controlIndex = (nextPointIsAnchor) ? i + 2 : i - 2;
            int anchorIndex = (nextPointIsAnchor) ? i + 1 : i - 1;

            if (controlIndex >= 0 && controlIndex < waypoints.Count)
            {
                float dst = (waypoints[anchorIndex] - waypoints[controlIndex]).magnitude;
                Vector2 dir = (waypoints[anchorIndex] - pos).normalized;
                waypoints[controlIndex] = waypoints[anchorIndex] + dir * dst;
            }

        }


    }



    public List<Vector2> GetPath()
    {

        foreach (Vector2 vector in waypoints)
        {
            Debug.Log(vector);
        }

        return waypoints;

    }

    public void SetPath(List<Vector2> waypoints)
    {

        this.waypoints = waypoints;
    }

}
