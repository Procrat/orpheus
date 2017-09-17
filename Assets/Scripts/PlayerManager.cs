using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	public GameObject player;
	public GameObject ghost;
    public float ghostPerishDelay;  // In seconds

	private Coroutine dieAfterAWhile;

	public AudioClip deathSound;
	public AudioClip possessSound;
	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
	}

	void Update()
	{
        if (Input.GetButtonDown ("Cancel")) {
            Debug.Log("Quitting level.");
            SceneManager.LoadScene("Start");
        }

        // Temporary shortcut to win
        /*if (Input.GetKeyDown ("space")) {
            Win ();
        }*/
	}

    public void Die ()
    {
		if (player == ghost) {
			Debug.Log("Internal error: Tried to die while already being a ghost!");
			return;
		}


		source.PlayOneShot (deathSound, 1f);

        Debug.Log ("Hooray! You die!");

		player.GetComponent<Player>().enabled = false;
        // Don't tag the currently possessed body as an enemy;
        // otherwise, we'll just possess it again.
        player.tag = "Untagged";
        ghost.transform.position = player.transform.position;
		ghost.SetActive(true);
		player = ghost;
        dieAfterAWhile = StartCoroutine (ActuallyDieAfterAWhile ());     
    }

	public void Possess(GameObject enemy) {
		
		source.PlayOneShot (possessSound, 1f);

		if (player != ghost) {
			Debug.Log("Internal error: Tried to possess while not being a ghost!");
			return;
		}

		Debug.Log("Possessing enemy!");

		ghost.SetActive(false);
		enemy.GetComponent<WalkerAI>().enabled = false;
		enemy.GetComponent<WalkerPlayer>().enabled = true;
		player = enemy;
		StopCoroutine(dieAfterAWhile);
	}

    IEnumerator ActuallyDieAfterAWhile ()
    {
        yield return new WaitForSeconds (ghostPerishDelay);
        Debug.Log("Awww. You lost.");
        // TODO change this once there is a death-scene
        SceneManager.LoadScene("Died");
    }

    public void Win ()
    {
        Debug.Log ("Hooray! You won!");
        SceneManager.LoadScene ("End");
    }
}
