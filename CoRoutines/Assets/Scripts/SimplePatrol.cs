using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour {

    public Transform target_01;
    public Transform target_02;

    private Vector3 startPos;
    public float moveTime;

	private void Start()
	{
        startPos = transform.position;
        StartCoroutine(MoveToTarget_01());
	}


    // Patrol

    IEnumerator MoveToTarget_01()
    {
        float t = 0f;

        while (t < moveTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target_01.position, t / moveTime);
            yield return new WaitForEndOfFrame();
        }
        startPos = transform.position;
        StartCoroutine(MoveTotarget_02());
    }

    IEnumerator MoveTotarget_02()
    {
        float t = 0;
        while(t < moveTime)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target_02.position, t / moveTime);
            yield return new WaitForEndOfFrame();
        }
        startPos = transform.position;
        StartCoroutine(MoveToTarget_01());
    }

    // End Patrol
}
