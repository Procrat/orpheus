using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTouch : MonoBehaviour {
	public string scene;

	void OnCollisionEnter2D(Collision2D other)
	{
		SceneManager.LoadScene (scene);
	}
}
