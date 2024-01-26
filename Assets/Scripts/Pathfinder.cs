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

    public bool CanMove = true;

    private void Start()
    {
       foreach(Transform waypoint in path)
       {
            waypoints.Add(waypoint);
       }

    }

    private void Update()
    {
        if(CanMove)
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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            CanMove = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            StartCoroutine(ResetMOvemtn());
        }
    }

    IEnumerator ResetMOvemtn ()
    {
        yield return new WaitForSeconds(1);
        CanMove = true;
    }

}
