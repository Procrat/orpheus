using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float verticalDisplacement;
    public float depth;
    public GameObject playerManagerObject;
    public GameObject leftBoundary;
    public GameObject bottomBoundary;
    public GameObject rightBoundary;
    public GameObject topBoundary;

    private PlayerManager playerManager;

    void Start()
    {
        playerManager = playerManagerObject.GetComponent<PlayerManager>();
    }

    void Update()
    {
        var player = playerManager.player;

        // Including walls
        var worldBoundingBox = Rect.MinMaxRect(leftBoundary.GetComponent<Collider2D>().bounds.min.x,
                                               bottomBoundary.GetComponent<Collider2D>().bounds.min.y,
                                               rightBoundary.GetComponent<Collider2D>().bounds.max.x,
                                               topBoundary.GetComponent<Collider2D>().bounds.max.y);
        // Excluding walls
        // var worldBoundingBox = Rect.MinMaxRect(leftBoundary.GetComponent<Collider2D>().bounds.max.x,
        //                                        bottomBoundary.GetComponent<Collider2D>().bounds.max.y,
        //                                        rightBoundary.GetComponent<Collider2D>().bounds.min.x,
        //                                        topBoundary.GetComponent<Collider2D>().bounds.min.y);
        var halfScreenDiagonal = (Vector2)(Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, depth))
                                            - Camera.main.ViewportToWorldPoint(new Vector3(0, 0, depth)));
        var cameraBoundingBox = new Rect(worldBoundingBox.min + halfScreenDiagonal,
                                         worldBoundingBox.size - 2 * halfScreenDiagonal);

        transform.position = player.transform.position + verticalDisplacement * Vector3.up;
        transform.position = Vector2.Max(transform.position, cameraBoundingBox.min);
        transform.position = Vector2.Min(transform.position, cameraBoundingBox.max);
        transform.Translate(depth * Vector3.back);
    }
}
