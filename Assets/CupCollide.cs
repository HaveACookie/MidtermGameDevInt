using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CupCollide : MonoBehaviour
{

	public Slider noiseMeter;
	public int noiseForMeter;
	public AudioSource impact;

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

		if (GameManager.Instance.Noise == 40)
		{
			GameManager.Instance.GameOver = true;
			SceneManager.LoadScene(2);
		}
	}


	private void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag.Equals("Wall"))
		{
			GameManager.Instance.Noise += 10;
			noiseForMeter = GameManager.Instance.Noise;
			impact.Play();

		}
	}
}
