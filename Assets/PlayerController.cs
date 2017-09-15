using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float feetWidth;

    public GameObject feet;
    public LayerMask whatIsGround;

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

        Move ();

        Jump ();

        // Temporary shortcut to win/die
        if (Input.GetKeyDown ("space")) {
            Win ();
        }
    }

    private void Move ()
    {
        var translationVector = new Vector2 (Input.GetAxis ("Horizontal"), 0);
        transform.Translate (moveSpeed * translationVector);
    }


    private void Jump ()
    {
        var feetRect = new Rect (0, 0, feetWidth, 0.01f);
        feetRect.center = feet.transform.position;
        Debug.DrawLine (feetRect.min, feetRect.max, Color.green);
        if (Input.GetButton ("Jump") && isGrounded ()) {
            body.velocity = jumpSpeed * Vector2.up;
        }
    }

    private bool isGrounded ()
    {
        var feetRect = new Rect (0, 0, feetWidth, 0.01f);
        feetRect.center = feet.transform.position;
        return Physics2D.OverlapArea (feetRect.min, feetRect.max, whatIsGround);
    }

    public void Win ()
    {
        Debug.Log ("Hooray! You won!");
        SceneManager.LoadScene ("End");
    }
}
