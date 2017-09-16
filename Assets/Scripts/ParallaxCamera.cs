using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://answers.unity3d.com/questions/551808/parallax-scrolling-using-orthographic-camera.html

 [ExecuteInEditMode]
 public class ParallaxCamera : MonoBehaviour 
 {
     public delegate void ParallaxCameraDelegate(float deltaMovement);
     public ParallaxCameraDelegate onCameraTranslate;
     private float oldPosition;
     void Start()
     {
         oldPosition = transform.position.x;
     }
     void Update()
     {
         if (transform.position.x != oldPosition)
         {
             if (onCameraTranslate != null)
             {
                 float delta = oldPosition - transform.position.x;
                 onCameraTranslate(delta);
             }
             oldPosition = transform.position.x;
         }
     }
 }