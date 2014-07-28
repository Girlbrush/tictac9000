using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {

	public Animator buttonAnim;
	public TicTacToe gm;

	// Use this for initialization
	void Start () {

		gm = GameObject.Find ("_GameManager").GetComponent<TicTacToe>();
		buttonAnim = this.GetComponentInChildren<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){

		gm.Restart ();
		AnimatePress ();

		print ("Hello!");

		if (Input.GetMouseButtonUp (0)) {

			AnimateRelease ();

				}
	}

	public void AnimatePress(){

		buttonAnim.SetTrigger ("pressed");
	}

	public void AnimateRelease(){

		buttonAnim.SetTrigger ("released");
	}

}
