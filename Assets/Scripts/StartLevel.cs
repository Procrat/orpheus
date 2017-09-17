using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
	public float startDelay;

	void Start ()
	{
		StartCoroutine (StartAfterDelay ());
	}

	IEnumerator StartAfterDelay ()
	{
		yield return new WaitForSeconds (startDelay);
		SceneManager.LoadScene ("Start");
	}
}