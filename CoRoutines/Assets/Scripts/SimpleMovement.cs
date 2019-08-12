using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{

    public Transform target;
    public float moveTime = 3f;

    private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SimpleMove());
        startPos = transform.position;
    }

    IEnumerator SimpleMove()
    {
        float t = 0f;

        while (t < moveTime)
        {
            t += Time.deltaTime;

            transform.position = Vector3.Lerp(startPos, target.position, t / moveTime);

            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
}
