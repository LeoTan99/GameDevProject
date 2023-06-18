using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
 
        if (SceneManager.GetActiveScene().name == "Leaderboard")
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "Easy Level")
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "Medium Level")
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "Hard Level")
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();

        if (SceneManager.GetActiveScene().name == "GameMP")
            BackgroundMusic.instance.GetComponent<AudioSource>().Pause();
    }
}
