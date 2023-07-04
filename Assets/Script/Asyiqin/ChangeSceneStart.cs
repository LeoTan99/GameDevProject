using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneStart : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        // Set the points patty to 0
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}

