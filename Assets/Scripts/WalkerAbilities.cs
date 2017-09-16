using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAbilities: MonoBehaviour {

	float walkSpeed = 2.0f;
	float walkingDirection = -1.0f; //positive is right, negative is left

	public void Move(float amount){
		Vector3 walkAmount = new Vector3();
		walkAmount.x = amount * walkSpeed * Time.fixedDeltaTime;
		//walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;

		transform.Translate(walkAmount);
	}
		
}
