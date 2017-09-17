using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : MonoBehaviour, State {

	public GameObject playerManager;
	public float moveSpeed = 2.0f;
	public float acceleration = 0.3f;
	private Rigidbody2D body;
	private float walkingDirection = -1f;
	float timeLeft = 6.0f;
	float length = 6.0f;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}

	void reset(){
		timeLeft = Random.Range(1f, length);
	}

	public void Move(float amount) {
		if (amount == 0) {
			moveSpeed = 2;
		}

		moveSpeed += acceleration * Time.fixedDeltaTime;
		var walkAmount = amount * moveSpeed * Time.fixedDeltaTime;

		transform.Translate(walkAmount * Vector2.right);

		AnimationScript animationScript = GetComponent<AnimationScript>();

		if(walkAmount < 0)
		{
			animationScript.ChangeAnim("WalkerWalk");
			animationScript.frameTime = 0.2f;
			animationScript.flipX = true;
		}
		else
			if(walkAmount > 0)
			{
				animationScript.ChangeAnim("WalkerWalk");
				animationScript.frameTime = 0.2f;
				animationScript.flipX = false;
			}
			else
			{
				animationScript.ChangeAnim("WalkerIdle");
				animationScript.frameTime = 0.4f;
			}


	}

	public void DoState(){

		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			walkingDirection = -1*walkingDirection;
			reset ();
		}

		Move(walkingDirection);

	}


	private void OnCollisionEnter2D(Collision2D collision) {
		//swap directions if you collide with one of the walls.
		if (collision.gameObject.tag == "LeftWall") {
			reset ();
			RunRight ();
		} else if (collision.gameObject.tag == "RightWall") {
			reset ();
			RunLeft ();
		}

		if (collision.gameObject.tag == "deadlyOnTouch") {
			Jump ();
		}
	}

	public void RunRight(){
		walkingDirection = 1f;
	}

	public void RunLeft(){
		walkingDirection = -1f;
	}


	private void Jump (){
		float jumpSpeed = 15;
		moveSpeed = 5;
		body.velocity = jumpSpeed * Vector2.up;
	}

}
