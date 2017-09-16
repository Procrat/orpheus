using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < player.transform.position.x) {
			transform.Translate (0.1f, 0, 0);
		}
	}
}
