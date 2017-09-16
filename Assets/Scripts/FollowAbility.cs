using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAbility : MonoBehaviour {
	
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	// Update is called once per frame
	public void Move () {
		
		if (transform.position.x < player.transform.position.x) {
			transform.Translate (0.01f, 0, 0);
		}

		if (transform.position.x > player.transform.position.x) {
			transform.Translate (-0.01f, 0, 0);
		}
	}

}
