using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public string triggerKey;
    public string nextSceneName;

    void Update ()
    {
        if (Input.GetKeyDown (triggerKey)) {
            SceneManager.LoadScene (nextSceneName);
        }
    }
}
