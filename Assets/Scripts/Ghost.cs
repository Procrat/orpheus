using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float floatSpeed;

    public GameObject playerManager;
    
    private bool gonnaPossess = false;
    private GameObject possessee = null;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemy") {
            playerManager.GetComponent<PlayerManager>().BeginPossess(other.gameObject);
        }
        else
        if(other.gameObject.name == "Lady")
        {
            playerManager.GetComponent<PlayerManager>().Win();
        }
    }

    private void FixedUpdate ()
    {
        if(gonnaPossess)
        {
            MoveTowards();
        }
        else FloatUp();
    }

    private void FloatUp() {
        transform.Translate (floatSpeed * Vector2.up);
    }
    
    public void GoAndPossess(GameObject possessee)
    {
        gonnaPossess = true;
        this.possessee = possessee;
    }
    
    private void MoveTowards()
    {
        Vector2 direction = possessee.transform.position - transform.position;
        Vector2 moveVector = Vector2.ClampMagnitude(direction, floatSpeed / 10);
        
        Debug.Log("ghostpos=" + transform.position + ", enemypos=" + possessee.transform.position);
        Debug.Log(direction.magnitude);
        //Debug.Log("moveMagnitude=" + moveVector.magnitude + ", floatSpeed=" + floatSpeed);
        if(moveVector.magnitude - (floatSpeed / 10) < 0.0001)
        {
            gonnaPossess = false;
            playerManager.GetComponent<PlayerManager>().ActuallyPossess(possessee);
        }
        else
        {
            transform.Translate(moveVector);
        }
    }
}
