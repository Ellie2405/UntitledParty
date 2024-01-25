using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float speed = 2f;

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
        float maxDelta = speed * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, maxDelta);

        if(this.transform.position == targetPosition)
        {
            pathIndex = (pathIndex + 1) % waypoints.Count;
        }
    }


}
