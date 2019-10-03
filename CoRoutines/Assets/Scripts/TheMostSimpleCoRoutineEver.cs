using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMostSimpleCoRoutineEver : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
        //This is the call to start the Co Routine - take not of the syntax...
        StartCoroutine(SimplestCoRoutine());
	}
	
	
    // Co Routines use the return typ IEnumerator - this is how you identify a CoRouting out in the wild.

    IEnumerator SimplestCoRoutine ()
    {

        //This is the body of the Co routine - do stuff here...
		yield return new WaitForSeconds(3);
        Debug.Log("Co Routine sucessfully called!");

        //Once we have completed all the tasks in the Co Routine, remember you always have to yield back
        // control or your code won't compile.
        yield return null;
    }
}
