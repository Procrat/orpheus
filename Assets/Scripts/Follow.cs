using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject toFollow;
    public GameObject leftBoundary;
    public GameObject bottomBoundary;
    public GameObject rightBoundary;
    public GameObject topBoundary;

    void Update ()
    {
        var worldBoundingBox = Rect.MinMaxRect(leftBoundary.GetComponent<Collider2D>().bounds.min.x,
                                               bottomBoundary.GetComponent<Collider2D>().bounds.min.y,
                                               rightBoundary.GetComponent<Collider2D>().bounds.max.x,
                                               topBoundary.GetComponent<Collider2D>().bounds.max.y);
        var halfScreenDiagonal = (Vector2) (Camera.main.ViewportToWorldPoint (new Vector2 (0.5f, 0.5f))
                                            - Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)));
        var cameraBoundingBox = new Rect(worldBoundingBox.min + halfScreenDiagonal,
                                         worldBoundingBox.size - halfScreenDiagonal);

		transform.position = toFollow.transform.position - 2.5f*Vector3.up;
        transform.position = Vector2.Max(transform.position, cameraBoundingBox.min);
        transform.position = Vector2.Min(transform.position, cameraBoundingBox.max);
        transform.Translate (10 * Vector3.back);
    }
}
