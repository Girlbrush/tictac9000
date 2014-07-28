using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TicTacToe : MonoBehaviour {

//	public CellDataClass CellData;
	public GameObject[] BrickArray;
	public 	List<Brick> brickScripts;
	bool currentPlayer;
	int winner = 0;

	bool roundCompleted = false;

	RaycastHit hit;

	Transform clickedBrick;

	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < BrickArray.Length; i++) {
			
			brickScripts.Add(BrickArray[i].GetComponent<Brick>());
			
		}

		SetBrickID ();
		RandomizeBeginner ();

	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){

			if(roundCompleted){
				return;
			}

			RaycastHit hit;
			if(Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition),out hit)){


				if(hit.collider != null){

					if(hit.transform.gameObject.tag == "Brick"){
						clickedBrick = hit.transform;
						CheckBrickOwner();
					}

					else if(hit.transform.gameObject.tag == "Button"){

						print ("Button clicked");
						ButtonPress b = hit.transform.GetComponent<ButtonPress>();
						b.OnClick ();

					}
				}		

			}

		}

	}

	void CheckBrickOwner(){

		print (clickedBrick.gameObject);
		Brick b = clickedBrick.GetComponent<Brick> ();

		if (b.owner == 0) {

			if(currentPlayer){

				b.owner = 1;

			}else if(!currentPlayer){

				b.owner = 2;
			}

			b.ActivateBrick();

			if(currentPlayer){

				currentPlayer = false;

			}else{
				currentPlayer = true;
			}

			CheckWin ();

		}

	}
	

	void RandomizeBeginner(){

		int randomPlayer = Random.Range(0,1);

		if (randomPlayer == 1)
		{
			currentPlayer = true;
		}else{
			currentPlayer = false;
		}
	}

	void SetBrickID(){

		int j = 1;

		for (int i = 0; i < BrickArray.Length; i++) {

			Brick b = BrickArray[i].GetComponent<Brick>();
			b.id = j;
			j++;

				}
	}

	void CheckWin(){

		//First Row Horizontal
		if (brickScripts[0].owner == brickScripts[1].owner && brickScripts[1].owner == brickScripts[2].owner) {
				print ("First Horizontal Win");

			if(brickScripts[0].owner == 0){
				return;
				}

			winner = brickScripts[0].owner;
			GameOver (winner);


			}

		
		//Second Row Horizontal
		if (brickScripts[3].owner == brickScripts[4].owner && brickScripts[4].owner == brickScripts[5].owner) {

			if(brickScripts[3].owner == 0){
				return;
			}

			winner = brickScripts[3].owner;
			GameOver (winner);

			print ("Second Horizontal Win");
				}

		//Third Row Horizontal
		if (brickScripts[6].owner == brickScripts[7].owner && brickScripts[7].owner == brickScripts[8].owner) {

			if(brickScripts[6].owner == 0){
				return;
			}

			winner = brickScripts[6].owner;
			GameOver (winner);

			print ("Third Horizontal Win");

				}

		//First Row Vertical
		if (brickScripts[0].owner == brickScripts[3].owner && brickScripts[3].owner == brickScripts[6].owner){
				

			if(brickScripts[0].owner == 0){
				return;
			}

			winner = brickScripts[0].owner;
			GameOver (winner);

			print ("First Vertical Win");
				}

		//Second Row Vertical
		if (brickScripts [1].owner == brickScripts [4].owner && brickScripts [4].owner == brickScripts [7].owner) {

			if(brickScripts[1].owner == 0){
				return;
			}

			winner = brickScripts[1].owner;
			GameOver (winner);

			print ("Second Vertical Win");

				}

		//Third Row Vertical
		if (brickScripts [2].owner == brickScripts [5].owner && brickScripts [5].owner == brickScripts [8].owner) {

			if(brickScripts[2].owner == 0){
				return;
			}

			winner = brickScripts[2].owner;
			GameOver (winner);

			print ("Third Vertical Win");
		}

		//Slash Diagonal
		if (brickScripts [0].owner == brickScripts [4].owner && brickScripts [4].owner == brickScripts [8].owner) {

			if(brickScripts[0].owner == 0){
				return;
			}

			winner = brickScripts[0].owner;
			GameOver (winner);

			print ("Slash Diagonal Win");
		}

		//Backslash Diagonal
		if (brickScripts [2].owner == brickScripts [4].owner && brickScripts [4].owner == brickScripts [6].owner) {

			if(brickScripts[2].owner == 0){
				return;
			}

			winner = brickScripts[2].owner;
			GameOver (winner);

			print ("BackSlash Diagonal Win");
		}


	}

	void GameOver(int i){

		roundCompleted = true;

		if (i == 0) {

			print ("It's a draw!");

			}

		else if(i == 1){

			print("X Won!");
		}

		else if (i == 2){

			print ("O Won!");
		}

	}

	public void Restart(){

		for (int i = 0; i < brickScripts.Count; i++) {

			brickScripts[i].DeactivateBrick();

				}
	
	}

}

