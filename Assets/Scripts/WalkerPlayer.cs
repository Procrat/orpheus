using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayer : Player {

    public GameObject playerManager;

    private WalkerAbilities abilityScript;

    // Use this for initialization
    void Start() {
        abilityScript = gameObject.GetComponent<WalkerAbilities>();
        
        Debug.Log(gameObject.name + " possessed!");
        abilityScript.Possess();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!enabled) {
            return;
        }
        if (collision.gameObject.tag == "deadlyOnTouch") {
            playerManager.SendMessage("Die");
            abilityScript.Die();
            return;
        }
    }

    void FixedUpdate() {
        float horizontalVelocity = Input.GetAxis("Horizontal");
        abilityScript.Move(horizontalVelocity, true);
    }
}
