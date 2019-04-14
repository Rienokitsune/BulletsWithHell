using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMoverSimple : PathMover
{
    
    int waypointIndex = 0;
    [SerializeField]float speed = 1;
    List<Vector2> waypoints;
    [SerializeField] bool looping;



    public override void Move()
    {
        MoveThroughWaypoints();
    }

    private void MoveThroughWaypoints()
    {
        if (waypointIndex <= waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex];
            var PosDelta = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, PosDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;

                if (waypointIndex == waypoints.Count && looping)
                {
                    waypointIndex = 0;
                }

                if(waypointIndex == waypoints.Count)
                {
                    Destroy(gameObject);
                }

                
            }
        }
    }

  /*  private void OnDrawGizmos()
    {
        Vector2 lastPos = waypoints[0];
        Gizmos.color = Color.white;
        foreach(Vector2 v2 in waypoints)
        {
            Gizmos.DrawLine(lastPos, v2);
            lastPos = v2;
            Gizmos.DrawSphere(v2, 0.1f);
        }
        
    }*/

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    } 
    
    public void setWaypoints()
    {
        waypoints = path.GetPath().waypoints;
    }
}
