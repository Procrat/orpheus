using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAbilities: MonoBehaviour {

	float walkSpeed = 2.0f;
	float acceleration = 0.3f;

	float walkingDirection = -1.0f; //positive is right, negative is left

	public void Move(float amount){

		if(walkSpeed > 2){
			walkSpeed = walkSpeed - 0.2f;
		}

		walkSpeed = walkSpeed + (acceleration*2);

		Vector3 walkAmount = new Vector3();
		walkAmount.x = amount * walkSpeed * Time.fixedDeltaTime;

		//walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		transform.Translate(walkAmount);
	}


	void OnCollisionEnter2D(Collision2D coll){
		//swap directions if you collide with one of the walls.

		if (coll.gameObject.tag == "LeftWall") {
			SetWalkSpeed (2f);
		}

		if (coll.gameObject.tag == "RightWall") {
			SetWalkSpeed (2f);
		}
	}


	public void SetWalkSpeed(float w){
		this.walkSpeed = w;
	}


}
