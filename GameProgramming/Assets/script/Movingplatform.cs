using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movingplatform : MonoBehaviour
{
    public Vector3[] waypoints;
    public float speed = 2f;
    public float waitTime = 1f;

    private int currentWaypointIndex;
    private bool isMoving;
    private Transform player;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //navMeshAgent = player.GetComponent<NavMeshAgent>();
        currentWaypointIndex = 0;
        isMoving = true;

        if (waypoints.Length > 0)
        {
            // Move the platform to the initial waypoint
            transform.position = waypoints[currentWaypointIndex];
        }
        
    }

    private void  FixedUpdate()
    {
        if (waypoints.Length > 0 && isMoving)
        {
            // Move the platform towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);

            if (transform.position == waypoints[currentWaypointIndex])
            {
                // Wait at the waypoint before moving to the next one
                inbox();
                StartCoroutine(WaitAtWaypoint());
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }

    void inbox()
    {
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        GetColliders().ForEach(A =>  Debug.Assert(A));
        
    }

    private IEnumerator WaitAtWaypoint()
    {
        isMoving = false;
        yield return new WaitForSeconds(waitTime);
        isMoving = true;
    }

    private List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders () { return colliders; }

    private void OnTriggerEnter (Collider other) {
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    private void OnTriggerExit (Collider other) {
        colliders.Remove(other);
    }
    
    
}
