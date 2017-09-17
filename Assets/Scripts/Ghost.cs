using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float floatSpeed;

    public GameObject playerManager;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            playerManager.SendMessage("Possess", other.gameObject);
        }
        else
        if(other.gameObject.name == "Lady")
        {
            playerManager.GetComponent<PlayerManager>().Win();
        }
    }

    private void FixedUpdate ()
    {
        FloatUp();
    }

    private void FloatUp() {
        transform.Translate (floatSpeed * Vector2.up);
    }
}
