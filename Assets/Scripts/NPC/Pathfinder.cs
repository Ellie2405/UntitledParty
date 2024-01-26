using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float speed = 100f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] DynamicSkin dynamicSkin;
    [SerializeField] GenericMask mask;

    private List<Transform> waypoints = new List<Transform>();
    private int pathIndex;
    private bool wasDirectionChecked = false;
    Vector3 targetPosition;

    public bool CanMove = true;

    private void Start()
    {
        dynamicSkin = GetComponent<DynamicSkin>();
        foreach (Transform waypoint in path)
        {
            waypoints.Add(waypoint);
        }

    }

    private void Update()
    {
        if (CanMove)
            FollowPath();

    }

    private void FollowPath()
    {
        if (Vector2.Distance(this.transform.position, targetPosition) < 1) //enter if arrived at target and needs to change direction
        {
            pathIndex = (pathIndex + 1) % waypoints.Count;
            targetPosition = waypoints[pathIndex].position;
            wasDirectionChecked = false;
        }

        rb.velocity = (targetPosition - this.transform.position).normalized * speed;

        if (!wasDirectionChecked) //change direction
        {
            int direction = CheckDirection();
            dynamicSkin.UpdateSkin(direction);
            mask.UpdateView(direction);
            wasDirectionChecked = true;
        }


    }

    int CheckDirection()
    {
        if (Mathf.Abs(rb.velocity.y) > Mathf.Abs(rb.velocity.x))
        {
            if (rb.velocity.y > 0)
            {
                return 1;
            }
            else return 0;
        }
        else
        {
            if (rb.velocity.x > 0)
            {
                return 3;
            }
            else return 2;
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

    IEnumerator ResetMOvemtn()
    {
        yield return new WaitForSeconds(1);
        CanMove = true;
    }

}
