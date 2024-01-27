using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Transform path;
    [SerializeField] float speed = 100f;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] DynamicSkin dynamicSkin;

    private List<Transform> waypoints = new List<Transform>();
    private int pathIndex;
    private bool wasDirectionChecked = false;
    Vector3 targetPosition;

    public bool canMove = true;

    protected void Start()
    {
        dynamicSkin = GetComponent<DynamicSkin>();
        foreach (Transform waypoint in path)
        {
            waypoints.Add(waypoint);
        }

    }

    private void Update()
    {
        //Debug.Log(Mathf.Atan2(rb.velocity.x, rb.velocity.y) * Mathf.Rad2Deg + 180);
        if (canMove)
        {
            //Debug.Log("CAn move");
            FollowPath();
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
            

    }

    private void FollowPath()
    {
        if (Vector2.Distance(this.transform.position, targetPosition) < 1) //enter if arrived at target and needs to change direction
        {
            pathIndex = (pathIndex + 1) % waypoints.Count;
            targetPosition = waypoints[pathIndex].position;
            wasDirectionChecked = false;
        }

        rigidBody.velocity = (targetPosition - this.transform.position).normalized * speed;

        if (!wasDirectionChecked) //change direction
        {
            dynamicSkin.UpdateSkin(CheckDirection());
            wasDirectionChecked = true;
        }


    }

    public int CheckDirection()
    {
        if (Mathf.Abs(rigidBody.velocity.y) > Mathf.Abs(rigidBody.velocity.x))
        {
            if (rigidBody.velocity.y > 0)
            {
                return 1;
            }
            else return 0;
            
        }
        else
        {
            if (rigidBody.velocity.x > 0)
            {
                return 3;
            }
            else return 2;
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            canMove = false;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger exited");
            StartCoroutine(ResetMOvemtn());
        }
    }

    protected IEnumerator ResetMOvemtn()
    {
        yield return new WaitForSeconds(1);
        canMove = true;
    }

}
