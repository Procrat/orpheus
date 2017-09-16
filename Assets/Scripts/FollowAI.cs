using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour {

	private FollowAbility abilityScript;

	void Start () {
		abilityScript = gameObject.GetComponent<FollowAbility> ();
	}

	void FixedUpdate () {
		abilityScript.Move ();
	}
		
}
