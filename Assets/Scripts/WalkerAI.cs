using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAI : MonoBehaviour {

	WalkerAbilities abilityScript;
	float walkingDirection = 1f;

	// Use this for initialization
	void Start () {
		abilityScript = gameObject.GetComponent<WalkerAbilities> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		abilityScript.Move (walkingDirection);
	}



	void OnCollisionEnter2D(Collision2D coll){
		//swap directions if you collide with one of the walls.

		if (coll.gameObject.tag == "LeftWall") {
			WalkRight ();
		}

		if (coll.gameObject.tag == "RightWall") {
			WalkLeft ();
		}
	}

	public void WalkRight(){
		walkingDirection = 1f;
	}

	public void WalkLeft(){
		walkingDirection = -1f;
	}




}
