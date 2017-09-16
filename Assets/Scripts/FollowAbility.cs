using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAbility : MonoBehaviour {


	public float moveSpeed;
	public float feetWidth;

	private GameObject player;

	public LayerMask whatIsGround;	
	private Rigidbody2D body;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		body = GetComponent<Rigidbody2D> ();	
	}

	// Update is called once per frame
	public void Move () {
		
		if (transform.position.x < player.transform.position.x) {
			transform.Translate (0.05f, 0, 0);
		}

		if (transform.position.x > player.transform.position.x) {
			transform.Translate (-0.05f, 0, 0);
		}

	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "deadlyOnTouch") {
			Jump ();
		}
	}
		

	private void Jump (){
		float jumpSpeed = 12;
		body.velocity = jumpSpeed * Vector2.up;
	}
}

