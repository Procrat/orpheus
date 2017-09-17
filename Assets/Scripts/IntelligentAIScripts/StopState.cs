using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopState : MonoBehaviour, State {

	public void DoState(){
		
		AnimationScript animationScript = GetComponent<AnimationScript>();

		animationScript.ChangeAnim("WalkerIdle");
		animationScript.frameTime = 0.4f;
	}

	public float getDirectionFacing(){
		return 0;
	}
}
