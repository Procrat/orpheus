using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligentAI : MonoBehaviour {

	private State currentState;
	private GameObject player;
	private PlayerManager playerManager;
	public Vector3 dir;
	bool following;

	float timeLeft = 2.0f;

	void Start () {
		this.currentState = GetComponent<WanderState> ();
		playerManager = GameObject.Find ("Player manager").GetComponent<PlayerManager>();
		player = playerManager.player;
	}


	void reset(){
		timeLeft = 2.0f;
	}

	void FixedUpdate () {

		currentState.DoState ();

		var distanceToPlayer = Vector3.Distance (transform.position, player.transform.position);
		dir = (player.transform.position - transform.position).normalized;
		if (distanceToPlayer < 4) {
			if (player.transform.position.x > transform.position.x && currentState.getDirectionFacing () == 1) {
				//follow
				currentState = GetComponent<AttackState> ();
				following = true;
			} else if (player.transform.position.x < transform.position.x && currentState.getDirectionFacing () == -1) {
				currentState = GetComponent<AttackState> ();
				following = true;
			}

		} else if (following == true) {
			this.currentState = GetComponent<StopState> ();
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				currentState = GetComponent<WanderState> ();
				following = false;
				reset ();
			}
		} else {
			currentState = GetComponent<WanderState> ();
		}


	}
}
