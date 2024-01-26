using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float speed = 100f;
    [SerializeField] Rigidbody2D rb;

    private List<Transform> waypoints = new List<Transform>();
    private int pathIndex;

    private void Start()
    {
       foreach(Transform waypoint in path)
       {
            waypoints.Add(waypoint);
       }

    }

    private void Update()
    {
       FollowPath();
    }

    private void FollowPath()
    {
        Vector3 targetPosition = waypoints[pathIndex].position;

        rb.velocity = (targetPosition - this.transform.position).normalized * speed;

        if(Vector2.Distance(this.transform.position, targetPosition) < 1)
        {
            pathIndex = (pathIndex + 1) % waypoints.Count;
        }
    }


}
