using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenSpeedPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public int nextWaypoint = -1;

    public float moveSpeed = 1f;

    private float startTime;

    private float journeyLength;
    private Vector3 startPos;
    private Vector3 targetPos;

	private void Start()
	{
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, waypoints[nextWaypoint + 1].position);
        MoveToNextWaypoint();

	}

    private void MoveToNextWaypoint()
    {
        Debug.Log("Moving to next Waypoint");
        startTime = Time.time;
        startPos = transform.position;
        nextWaypoint = (nextWaypoint + 1) % waypoints.Length;
        journeyLength = Vector3.Distance(startPos, waypoints[nextWaypoint].position);
    
    }

	private void Update()
	{
        float distCovered = (Time.time - startTime) * moveSpeed;
        float fracJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startPos, waypoints[nextWaypoint].position, fracJourney);
        if(fracJourney > .95f)
        {
            MoveToNextWaypoint();
        }
	}
}
