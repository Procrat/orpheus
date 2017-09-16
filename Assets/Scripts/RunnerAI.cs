using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAI : MonoBehaviour {

	private RunnerAbilities abilityScript;
	private float walkingDirection = -1f;

	void Start () {
		abilityScript = gameObject.GetComponent<RunnerAbilities> ();
	}

	void FixedUpdate () {
		abilityScript.Move (walkingDirection);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		//swap directions if you collide with one of the walls.
		if (collision.gameObject.tag == "LeftWall") {
			RunRight ();
		} else if (collision.gameObject.tag == "RightWall") {
			RunLeft ();
		}
	}

	public void RunRight(){
		walkingDirection = 1f;
	}

	public void RunLeft(){
		walkingDirection = -1f;
	}
}
