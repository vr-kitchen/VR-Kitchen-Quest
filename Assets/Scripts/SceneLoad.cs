using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{

    public GameObject playerToDestroyOnLoad;




    public void deleteplayer()
    {
        if (playerToDestroyOnLoad != null)
        {
            GameObject.Destroy(playerToDestroyOnLoad);
        }
    }
    public void LoadTheScene(int i)
    {
        if (playerToDestroyOnLoad != null)
        {
            GameObject.Destroy(playerToDestroyOnLoad);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);

        // SceneManager.LoadScene(SceneManager.GetSceneAt(i));
    }
    public void LoadThatOneScene(int i)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);

        // SceneManager.LoadScene(SceneManager.GetSceneAt(i));
    }
    public void AsyncLoadTheScene(int i)
    {
        deleteplayer();
        SceneManager.LoadScene(i);
    }
}