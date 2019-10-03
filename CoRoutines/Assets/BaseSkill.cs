using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class BaseSkill : MonoBehaviour
{

	private Slider _coolDownSlider;
	public Sprite IconImage;
	public string SkillName = "";
	
	[Space] public float CoolDownTime = 3f;

	private bool _locked = false;
	private Image _iconImage;

	private void Awake()
	{
		_iconImage = GetComponentInChildren<Image>();
		_iconImage.sprite = IconImage;

		_coolDownSlider = GetComponentInChildren<Slider>();
	}


	// This is a simple countdown Coroutine
	// a while loop is used until the arbitrary variable t
	// is less than the cooldownTime
	IEnumerator CoolDown(float coolDownTime)
	{
		float t = 0f;

		while (t < coolDownTime)
		{
			_locked = true;
			_coolDownSlider.value = t / coolDownTime;
			t += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		//Once the countdown has ended, we reset the slider
		// value back to 0 and unlock the asset, ready to be used again
		_locked = false;
		_coolDownSlider.value = 0f;
		yield return null;
	}
	
	
	// This function is the UI button Handler
	// It checks to see if the cooldown is currently
	// Running, if not it starts it.

	public void SkillOnClick()
	{
		if (!_locked)
		{
			Debug.Log("Starting Coroutine");
			StartCoroutine(CoolDown(CoolDownTime));
		}

		
	}

	
}
