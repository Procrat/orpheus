using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

	float walkSpeed = 2.0f;
	float walkingDirection = -1.0f; //positive is right, negative is left

	Vector3 walkAmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		transform.Translate(walkAmount);
	}

	void OnCollisionEnter2D(Collision2D coll){

		//swap directions if you collide with one of the walls.

		if (coll.gameObject.tag == "LeftWall") {
			walkingDirection = 1f;
		}

		if (coll.gameObject.tag == "RightWall") {
			walkingDirection = -1f;
		}
	}


}
