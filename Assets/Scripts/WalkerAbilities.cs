using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAbilities: MonoBehaviour {

	public string animationPrefix = "Walker/Walker";
    public float walkSpeed = 2.0f;
    public float acceleration = 0.3f;
	private string state = "alive";
	private AnimationScript animationScript;
	
	void Awake()
	{
		animationScript = GetComponent<AnimationScript>();
	}
	
    public void Move(float amount, bool isPlayer) {
		if(state != "alive") return;
		
        if (amount == 0) {
            walkSpeed = 2;
        }

        walkSpeed += acceleration * Time.fixedDeltaTime;
        var walkAmount = amount * walkSpeed * Time.fixedDeltaTime;

        transform.Translate(walkAmount * Vector2.right);
		
		string suffix = (isPlayer) ? "-P" : "";
		
		if(walkAmount < 0)
		{
			animationScript.ChangeAnim(animationPrefix + "Move" + suffix);
			animationScript.frameTime = 0.2f;
			animationScript.flipX = true;
		}
		else
		if(walkAmount > 0)
		{
			animationScript.ChangeAnim(animationPrefix + "Move" + suffix);
			animationScript.frameTime = 0.2f;
			animationScript.flipX = false;
		}
		else
		{
			animationScript.ChangeAnim(animationPrefix + "Idle" + suffix);
			animationScript.frameTime = 0.4f;
		}
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "LeftWall" || collision.gameObject.tag == "RightWall") {
            SetWalkSpeed(2f);
        }
    }

    public void SetWalkSpeed(float speed) {
        this.walkSpeed = speed;
    }
	
	public void Die()
	{
		animationScript.ChangeAnim(animationPrefix + "Death", false);
		animationScript.frameTime = 0.13f;
		state = "dead";
	}
	
	public void Possess()
	{
		animationScript.ChangeAnim(animationPrefix + "Possess", false, AfterAnim);
		animationScript.frameTime = 0.13f;
		state = "possess";
		SetWalkSpeed(2f);
	}
	
	private void AfterAnim(string anim)
	{
		if(anim == animationPrefix + "Possess")
		{
			state = "alive";
		}
	}
}

