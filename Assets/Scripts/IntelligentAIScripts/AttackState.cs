using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonoBehaviour, State {

	public GameObject playerManager;
	private PlayerManager playerManagerScript;
	private GameObject player;
	public float moveSpeed = 2.0f;
	public float acceleration = 0.3f;
	private Rigidbody2D body;
	public float walkingDirection = -1f;


	void Start () {
		body = GetComponent<Rigidbody2D> ();
		playerManagerScript = playerManager.GetComponent<PlayerManager> ();
		player = playerManagerScript.player;
	}


	public float getDirectionFacing(){
		return walkingDirection;
	}
		
	public void Move(float amount) {

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
		Move(walkingDirection);

	}


	private void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "deadlyOnTouch") {
			Jump ();
		}

		/*
		if (collision.gameObject == player) {
			if (player is WalkerPlayer) {
				(WalkerPlayer) player = player;
				player.getBody().velocity = 5 * Vector2.up;
			}
				//body.velocity = jumpSpeed * Vector2.up;
		}
		*/

		if (collision.gameObject.tag == "Player") {
			playerManagerScript.Die ();
		}

	}

	public void RunRight(){
		walkingDirection = 1f;
	}

	public void RunLeft(){
		walkingDirection = -1f;
	}


	public void Jump (){
		float jumpSpeed = 15;
		moveSpeed = 5;
		body.velocity = jumpSpeed * Vector2.up;
	}

}
