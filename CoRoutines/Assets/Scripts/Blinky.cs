using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinky : MonoBehaviour 
{

    public Color color = Color.green;
    public float blinkTime = .5f;

    private SpriteRenderer _spr;

	// Use this for initialization
	void Start () 
    {
        _spr = GetComponent<SpriteRenderer>();
        _spr.color = color;


        StartCoroutine(Blinker());
	}
	
    IEnumerator Blinker()
    {
        _spr.color = color;
        yield  return new WaitForSeconds(blinkTime);

        _spr.color = Color.clear;
        yield return new WaitForSeconds(blinkTime);

        StartCoroutine(Blinker());

    }
}
