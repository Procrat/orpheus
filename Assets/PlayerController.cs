
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D body;

    void Start ()
    {
        body = GetComponent<Rigidbody2D> ();
    }

    void FixedUpdate ()
    {
        HandleInput ();
    }

    private void HandleInput ()
    {
        if (Input.GetButtonDown ("Cancel")) {
            Debug.Log ("Quitting.");
            Application.Quit ();
        }

        Move (Input.GetAxis ("Horizontal"));

        // Temporary shortcut to win/die
        if (Input.GetKeyDown ("space")) {
            Win ();
        }
    }

    private void Move (float horizontalTranslation)
    {
        var translationVector = new Vector2 (horizontalTranslation, 0);
        transform.Translate (moveSpeed * translationVector);
    }

    public void Win ()
    {
        Debug.Log ("Hooray! You won!");
        SceneManager.LoadScene ("End");
    }
}
