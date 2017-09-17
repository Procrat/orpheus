using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : Player {

	public GameObject playerManager;
    public float walkSpeed = 2.0f;
	private string state = "alive";
	private AnimationScript animationScript;
	
	void Awake()
	{
		animationScript = GetComponent<AnimationScript>();
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (!enabled) {
            return;
        }
        if (collision.gameObject.tag == "deadlyOnTouch") {
            playerManager.SendMessage("Die");
            Die();
            return;
        }
    }

    void FixedUpdate() {
        float horizontalVelocity = Input.GetAxis("Horizontal");
        Move(horizontalVelocity);
    }
	
	public void Move(float amount) {
		if(state != "alive") return;
		
        /*if (amount == 0) {
            walkSpeed = 2;
        }*/
		
        var walkAmount = amount * walkSpeed * Time.fixedDeltaTime;

        transform.Translate(walkAmount * Vector2.right);
		
		if(walkAmount < 0)
		{
			animationScript.ChangeAnim("Hero/HeroWalk");
			animationScript.frameTime = 0.2f;
			animationScript.flipX = true;
		}
		else
		if(walkAmount > 0)
		{
			animationScript.ChangeAnim("Hero/HeroWalk");
			animationScript.frameTime = 0.2f;
			animationScript.flipX = false;
		}
		else
		{
			animationScript.ChangeAnim("Hero/HeroIdle");
			animationScript.frameTime = 0.4f;
		}
    }
	
	public void Die()
	{
		animationScript.ChangeAnim("Hero/HeroDeath", false);
		animationScript.frameTime = 0.13f;
		state = "dead";
	}
}
