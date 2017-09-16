using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerPlayer : MonoBehaviour {

    public GameObject playerManager;

    private WalkerAbilities abilityScript;

    // Use this for initialization
    void Start() {
        abilityScript = gameObject.GetComponent<WalkerAbilities>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!enabled) {
            return;
        }
        if (collision.gameObject.tag == "deadlyOnTouch") {
            Debug.Log("Collided w/" + collision.gameObject);
            playerManager.SendMessage("Die");
            return;
        }
    }

    void FixedUpdate() {
        float horizontalVelocity = Input.GetAxis("Horizontal");
        abilityScript.Move(horizontalVelocity);
    }
}
