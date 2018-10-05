using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardCast : MonoBehaviour {
	public Transform sightStart, sightEnd;
	public Transform lSideStart, LSideEnd;
	public Transform rSideStart, rSideEnd;
	public Transform lSoftStart, lSoftEnd;
	public Transform rSoftStart, rSoftEnd; 
	public bool spotted = false; 
	public bool lSpotted = false; 
	public bool rSpotted = false;
	public bool lSoftAlert = false; 
	public bool rSoftAlert = false; 
	public bool gameOverz= false;
    public AudioClip softAlert;
    public AudioSource enemyAudio;
    public GameObject Exclaim;
    // Use this for initialization
    void Start ()
    {
	  
    }

	// Update is called once per frame
	void Update () {
		Raycasting ();
		gameOver ();
		
	}

	void Raycasting(){
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.cyan);
		spotted = Physics.Linecast (sightStart.position, sightEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (lSideStart.position, LSideEnd.position, Color.magenta);
		lSpotted = Physics.Linecast (lSideStart.position, LSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (rSideStart.position, rSideEnd.position, Color.yellow);
		rSpotted = Physics.Linecast (rSideStart.position, rSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (lSoftStart.position, lSoftEnd.position, Color.white);
		lSoftAlert = Physics.Linecast (lSoftStart.position, lSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (rSoftStart.position, rSoftEnd.position, Color.white);
		rSoftAlert = Physics.Linecast (rSoftStart.position, rSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
	}

	void gameOver(){
		if (spotted || lSpotted || rSpotted) {

			gameOverz = true; 
		}
        if (lSoftAlert || rSoftAlert)
        {
            enemyAudio.PlayOneShot(softAlert);
	        GameManager.Instance.PFindDisable = false;
	       Debug.Log(GameManager.Instance.PFindDisable);

	        //Exclaim.SetActive(true);
        }
        if(!lSoftAlert || !rSoftAlert)
        {
	        GameManager.Instance.PFindDisable = true;
	        Debug.Log(GameManager.Instance.PFindDisable);

	        //Exclaim.SetActive(false);

        }
		if (gameOverz == true) {
			
			//WaitForSeconds(3);
			//SceneManager.LoadScene (4);
		}
		
	}

}
