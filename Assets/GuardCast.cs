using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardCast : MonoBehaviour {
	public Transform sightStart, sightEnd;
	public Transform lSideStart, LSideEnd;
	public Transform rSideStart, rSideEnd;
	public Transform lSoftStart, lSoftEnd;
	//public Transform lRSoftStart, lRSoftEnd;
	//public Transform lLSoftStart, lLSoftEnd;
	public Transform rSoftStart, rSoftEnd;
	//public Transform rRSoftStart, rRSoftEnd;
	//public Transform rLSoftStart, rLSoftEnd;
	public Transform fSoftStart, fSoftEnd;
	public Transform softStartReg, softEndReg;
	//public Transform fRSoftStart, fRSoftEnd;
	//public Transform fLSoftStart, fLSoftEnd;
	public bool spotted = false; 
	public bool lSpotted = false; 
	public bool rSpotted = false;
	public bool lSoftAlert = false; 
	public bool rSoftAlert = false;

	public bool softAlertReg1 = false;
	//public bool rRSoftAlert = false;
	//public bool rLSoftAlert = false;
public bool fSoftAlert = false;
//	public bool fRSoftAlert = false;
	//public bool fLSoftAlert = false; 
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
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.magenta);
		spotted = Physics.Linecast (sightStart.position, sightEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (lSideStart.position, LSideEnd.position, Color.magenta);
		lSpotted = Physics.Linecast (lSideStart.position, LSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (rSideStart.position, rSideEnd.position, Color.magenta);
		rSpotted = Physics.Linecast (rSideStart.position, rSideEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (lSoftStart.position, lSoftEnd.position, Color.white);
		lSoftAlert = Physics.Linecast (lSoftStart.position, lSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
//		Debug.DrawLine (rRSoftStart.position, rRSoftEnd.position, Color.green);
		//rRSoftAlert = Physics.Linecast (rRSoftStart.position, rRSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		//Debug.DrawLine (rLSoftStart.position, rLSoftEnd.position, Color.white);
		//rLSoftAlert = Physics.Linecast (rLSoftStart.position, rLSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (rSoftStart.position, rSoftEnd.position, Color.white);
		rSoftAlert = Physics.Linecast (rSoftStart.position, rSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (fSoftStart.position, fSoftEnd.position, Color.white);
		fSoftAlert = Physics.Linecast (fSoftStart.position, fSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		//Debug.DrawLine (fRSoftStart.position, fRSoftEnd.position, Color.green);
		//fRSoftAlert = Physics.Linecast (fRSoftStart.position, fRSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		//Debug.DrawLine (fLSoftStart.position, rLSoftEnd.position, Color.green);
		//fLSoftAlert = Physics.Linecast (fLSoftStart.position, fLSoftEnd.position, 1<< LayerMask.NameToLayer("Player"));
		Debug.DrawLine (softStartReg.position, softEndReg.position, Color.white);
		softAlertReg1 = Physics.Linecast (softStartReg.position, softEndReg.position, 1<< LayerMask.NameToLayer("Player"));
	}

	void gameOver(){
		if (spotted || lSpotted || rSpotted) {

			gameOverz = true; 
		}
        if (lSoftAlert || rSoftAlert || softAlertReg1)
        {
	        if (!enemyAudio.isPlaying)
	        {
		        enemyAudio.PlayOneShot(softAlert);
	        }
            
	      
	        
	        GameManager.Instance.PFindDisable = false;
	       Debug.Log(GameManager.Instance.PFindDisable);

	        //Exclaim.SetActive(true);
        }
       else if(!lSoftAlert || !rSoftAlert)
        {
	        GameManager.Instance.PFindDisable = true;
	        Debug.Log(GameManager.Instance.PFindDisable);

	        //Exclaim.SetActive(false);

        }
		if (gameOverz == true) {
			
			//WaitForSeconds(3);
			SceneManager.LoadScene (2);
		}
		
	}

}
