using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float floatSpeed;
    public float feetWidth;

    public GameObject feet;
    public LayerMask whatIsGround;
    public GameObject ghostColliderObject;

    private Rigidbody2D body;
    private Collider2D possessedCollider;
    private Collider2D ghostCollider;
    private bool isGhost;

    void Start ()
    {
        body = GetComponent<Rigidbody2D> ();
        possessedCollider = GetComponent<BoxCollider2D>();
        ghostCollider = ghostColliderObject.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate ()
    {
        HandleInput ();
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (!isGhost) {
            if (collision.gameObject.tag == "deadlyOnTouch") {
                Die ();
            }
        } else {
            if (collision.gameObject.tag == "enemy") {
                // TODO take over enemy
            }
        }
    }

    private void HandleInput ()
    {
        if (Input.GetButtonDown ("Cancel")) {
            Debug.Log ("Quitting.");
            Application.Quit ();
        }

        if (isGhost) {
            FloatUp();
        } else {
            Move();
            Jump ();
        }

        // Temporary shortcut to win
        if (Input.GetKeyDown ("space")) {
            Win ();
        }
    }

    private void FloatUp() {
        transform.Translate (floatSpeed * Vector2.up);
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

    private void Die ()
    {
        Debug.Log ("Hooray! You die!");
        // TODO Do some animation to turn into a ghost (and perhaps slowly fade away)
        GetComponent<SpriteRenderer>().color = Color.red;
        // TODO Make new game object of lifeless body that we're levaing
        isGhost = true;
        body.isKinematic = true;
        possessedCollider.enabled = false;
        ghostCollider.enabled = true;
    }

    private void Win ()
    {
        Debug.Log ("Hooray! You won!");
        SceneManager.LoadScene ("End");
    }
}
