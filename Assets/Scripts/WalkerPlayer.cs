using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayer : MonoBehaviour {

	private WalkerAbilities abilityScript;

	// Use this for initialization
	void Start () {
		abilityScript = gameObject.GetComponent<WalkerAbilities> ();
	}

	void FixedUpdate(){
		float horizontalVelocity = Input.GetAxis("Horizontal");
		abilityScript.Move (horizontalVelocity);
	}
}
