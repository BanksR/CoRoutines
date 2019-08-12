using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherPatrol : MonoBehaviour {



    public Transform[] waypoints;
    public float moveTime = 3f;

    private Vector3 startPos;
    private Transform targetPos;

    private int currentWaypoint = 0;

	private void Start()
	{
        StartCoroutine(MoveToWaypoint(waypoints[0]));
	}


	private void MoveToNextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        targetPos = waypoints[currentWaypoint];
        Debug.Log("Moving to Waypoint :" + currentWaypoint);
        StartCoroutine(MoveToWaypoint(targetPos));
    }

    IEnumerator MoveToWaypoint(Transform wp)
    {
        float t = 0;
        startPos = transform.position;
        while (t < moveTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, wp.position, t / moveTime);
            yield return new WaitForEndOfFrame();
        }

        MoveToNextWaypoint();
    }

}
