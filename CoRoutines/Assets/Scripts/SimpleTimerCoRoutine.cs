using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimerCoRoutine : MonoBehaviour {



	private void Start()
	{
        StartCoroutine(SimpleTimer());

	}


	IEnumerator SimpleTimer()
    {
        
        yield return new WaitForSeconds(3);
        Debug.Log("I have waited 3 Seconds...");
    }
}
