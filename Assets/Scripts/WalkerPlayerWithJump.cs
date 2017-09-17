using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayerWithJump : MonoBehaviour {

	public GameObject playerManager;

	private WalkerAbilities abilityScript;

	public float jumpSpeed;
	public float feetWidth;
	public GameObject feet;
	public LayerMask whatIsGround;
	private Rigidbody2D body;

	bool onGround;

	void Awake(){
		jumpSpeed = 12;
	}

	void Start() {
		body = GetComponent<Rigidbody2D> ();
		abilityScript = gameObject.GetComponent<WalkerAbilities>();

		Debug.Log(gameObject.name + " possessed!");
		abilityScript.Possess();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (!enabled) {
			return;
		}
		if (collision.gameObject.tag == "deadlyOnTouch") {
			playerManager.SendMessage("Die");
			abilityScript.Die();
			return;
		}

		if (collision.gameObject.tag == "ground") {
			onGround = true;
		} else {
			onGround = false;
		}
	}

	void FixedUpdate() {
		float horizontalVelocity = Input.GetAxis("Horizontal");
		abilityScript.Move(horizontalVelocity, true);
		Jump ();
	}


	private void Jump ()
	{
		var feetRect = new Rect (0, 0, feetWidth, 0.01f);
		feetRect.center = feet.transform.position;
		Debug.DrawLine (feetRect.min, feetRect.max, Color.green);
		if (Input.GetButton ("Jump") && onGround) {
			body.velocity = jumpSpeed * Vector2.up;
		}
	}

}
