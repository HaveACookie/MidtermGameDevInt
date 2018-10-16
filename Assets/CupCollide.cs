using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupCollide : MonoBehaviour
{

	public Slider noiseMeter;
	public int noiseForMeter;

	// Use this for initialization
	void Start ()
	{
		GameManager.Instance.Noise = 0;
		noiseForMeter = GameManager.Instance.Noise;
	}
	
	// Update is called once per frame
	void Update ()
	{
		noiseMeter.value = noiseForMeter;
		
		if (GameManager.Instance.GameOver == true)
		{
			Debug.Log("GameOver!!");
			//Add Scene Manager to game over screen
			
			
		}

		if (GameManager.Instance.Noise == 100)
		{
			GameManager.Instance.GameOver = true;
		}
	}


	private void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag.Equals("Wall"))
		{
			GameManager.Instance.Noise += 10;
			noiseForMeter = GameManager.Instance.Noise;

		}
	}
}
