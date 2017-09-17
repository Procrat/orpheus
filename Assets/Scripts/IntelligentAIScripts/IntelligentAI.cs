using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligentAI : MonoBehaviour {

	private State currentState;
	private GameObject player;
	private PlayerManager playerManager;

	// Use this for initialization
	void Start () {
		this.currentState = WanderState;
		playerManager = GameObject.Find ("Player manager").GetComponent<PlayerManager>();
		player = playerManager.player;
	}
	
	// Update is called once per frame
	void Update () {

		currentState.DoState ();

		Vector3 distanceToPlayer = Vector3.Distance ((Vector2)transform.position, (Vector2)player.transform.position);

		if(WanderState.){

		}

	}
}
