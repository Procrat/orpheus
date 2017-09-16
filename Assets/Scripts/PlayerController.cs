using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float feetWidth;

    public GameObject playerManager;
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

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "deadlyOnTouch") {
            playerManager.SendMessage("Die");
        }
    }

    private void HandleInput ()
    {
        Move();
        Jump ();
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
}
