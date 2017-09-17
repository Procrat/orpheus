using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAI : MonoBehaviour {

    private WalkerAbilities abilityScript;
    private float walkingDirection = -1f;

    void Start() {
        abilityScript = gameObject.GetComponent<WalkerAbilities>();
    }

    void FixedUpdate() {
        abilityScript.Move(walkingDirection, false);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!enabled) {
            return;
        }
        //swap directions if you collide with one of the walls.
        if (collision.gameObject.tag == "LeftWall") {
            WalkRight();
        } else if (collision.gameObject.tag == "RightWall") {
            WalkLeft();
        }
    }

    public void WalkRight() {
        walkingDirection = 1f;
    }

    public void WalkLeft() {
        walkingDirection = -1f;
    }
}
