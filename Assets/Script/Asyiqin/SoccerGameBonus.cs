using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class SoccerGameBonus : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownDuration = 5f;
    public float gameTimeDuration = 10f;
    private float timeRemaining;
    public string goToScene;

    private bool isGameStarted = false;

    public string currentScene;
    [SerializeField] private AudioSource SoundEffect;

    public GameObject canvasMenu;
    public GameObject canvasWelcome;
    public GameObject canvasCompleted;

    private void Start()
    {
        StartCoroutine(ActivateCanvasWelcome());

        timeRemaining = gameTimeDuration;

        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator ActivateCanvasWelcome()
    {
        yield return new WaitForSeconds(3f);
        canvasWelcome.SetActive(false);
    }

    private IEnumerator CountdownCoroutine()
    {
        // Countdown
        float countdownTimer = countdownDuration;
        while (countdownTimer >= 1)
        {
            timerText.text = countdownTimer.ToString("0");
            yield return new WaitForSeconds(1f);
            countdownTimer--;
        }

        // Display "Start"
        timerText.text = "Start";
        isGameStarted = true;
        SoundEffect.Play();
        yield return new WaitForSeconds(1f);

        GameObject.FindGameObjectWithTag("Target").GetComponent<PlayerMovement>().enabled = true;

        // Game Time
        float gameTimer = 0f;
        while (gameTimer <= gameTimeDuration)
        {
            if (isGameStarted)
            {
                timerText.text = FormatTime(timeRemaining);
                gameTimer++;

                timeRemaining--;
            }
            yield return new WaitForSeconds(1f);
        }

        // Game Over
        timerText.text = "Game Over";
        isGameStarted = false;

        canvasMenu.SetActive(false);
        canvasCompleted.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(goToScene);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
