using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAbilities: MonoBehaviour {

	public float walkSpeed = 2.0f;
	public float acceleration = 0.3f;
    public GameObject playerManager;

	public void Move(float amount) {
		if (amount == 0) {
			walkSpeed = 2;
		}

		walkSpeed += acceleration * Time.fixedDeltaTime;
		var walkAmount = amount * walkSpeed * Time.fixedDeltaTime;

		transform.Translate(walkAmount * Vector2.right);
	}

	void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "deadlyOnTouch") {
            playerManager.SendMessage("Die");
			return;
        }

		if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall") {
			SetWalkSpeed (2f);
		}
	}

	public void SetWalkSpeed(float speed) {
		this.walkSpeed = speed;
	}
}
