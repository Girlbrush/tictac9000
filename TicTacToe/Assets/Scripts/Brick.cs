using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int id;
	public int owner = 0;
	public GameObject X;
	public GameObject O;

	public Animator anim;

	public bool sleepState;

	void Awake(){

		anim = this.gameObject.GetComponentInChildren<Animator> ();

	}

	void Start () {

		X = transform.FindChild ("Brick_X").gameObject;
		O = transform.FindChild ("Brick_O").gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.A)) {

			AnimateSquint ();
				}

		if (anim != null) {
						if (anim.GetCurrentAnimatorStateInfo (0).IsName ("sleep")) {
								// Avoid any reload.
								print ("Hello!");
								sleepState = true;
						} else if (sleepState) {
								sleepState = false;
								print ("Sleep done");
						}
				}
	
	}

	public void ActivateBrick(){

		if (owner == 1) {

			X.SetActive(true);
			anim = X.GetComponent<Animator>();

			} else if (owner == 2){

			O.SetActive(true);
			anim = O.GetComponent<Animator>();

			}


	}

	public void AnimateSquint(){

		anim.SetTrigger ("squint");

	}

	public void DeactivateBrick(){

		if(anim != null)
		anim.SetTrigger ("sleep");
	}



}
