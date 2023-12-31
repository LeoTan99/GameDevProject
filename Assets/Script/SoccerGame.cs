using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class SoccerGame : MonoBehaviour
{
    PhotonView view;
    public TextMeshProUGUI timerText;
    public float countdownDuration = 5f;
    public float gameTimeDuration = 10f;
    private float timeRemaining;
    /*public string goToScene;*/
    public string goToBonusLevelScene;
    public string goToMenuLevelScene;

    private bool isGameStarted = false;
    private int playerScore = 0;
    private int aiScore = 0;
    private string scoreGame;
    public string sceneMP;

    public GameObject canvasMenu;
    public GameObject canvasWin;
    public GameObject canvasLose;

    public string currentScene;
    [SerializeField] private AudioSource SoundEffect;

    private void Start()
    {
        //currentSceneName = SceneManager.GetActiveScene().name;
        view = GetComponent<PhotonView>();
        StartCoroutine(CountdownCoroutine());

        timeRemaining = gameTimeDuration;

        FindAnyObjectByType<GameManager>().destroyBurger();
    }

    private IEnumerator CountdownCoroutine()
    {
        

        // Countdown
        float countdownTimer = countdownDuration;
        while (countdownTimer >= 1)
        {
            FindAnyObjectByType<GameManager>().destroyBurger();

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
        FindAnyObjectByType<AiOpponent>().enabled = true;

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
        int goalScore = FindObjectOfType<Goal>().score;
        scoreGame = (goalScore * 10).ToString(); //this is only example calculation for score
        Debug.Log(scoreGame);
        saveScore();

        /*SceneManager.LoadScene(goToScene);*/
        playerScore = FindObjectOfType<Goal>().score;
        aiScore = FindObjectOfType<AIGoal>().score;

        CompareScoresAndLoadLevel();
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CompareScoresAndLoadLevel()
    {
        if (playerScore > aiScore)
        {
            StartCoroutine(ShowCanvasWinAndLoadLevel());
        }
        else
        {
            StartCoroutine(ShowGameOverAndLoadLevel());
        }

        if (currentScene == "BonusLevel")
        {
            SceneManager.LoadScene(goToMenuLevelScene);
        }
    }

    private IEnumerator ShowCanvasWinAndLoadLevel()
    {
        canvasMenu.SetActive(false);
        canvasWin.SetActive(true);
        yield return new WaitForSeconds(5f);
        canvasWin.SetActive(false);

        SceneManager.LoadScene(goToBonusLevelScene);
    }

    private IEnumerator ShowGameOverAndLoadLevel()
    {
        canvasMenu.SetActive(false);
        canvasLose.SetActive(true);
        yield return new WaitForSeconds(5f);
        canvasLose.SetActive(false);

        SceneManager.LoadScene(goToMenuLevelScene);
    }

    public void saveScore()
    {
        FindObjectOfType<APISystem>().InsertPlayerActivity(PlayerPrefs.GetString("username"), "metricpoint_05", "add", scoreGame); //this is how we send score to Tenenet
    }

    // private void Update()
    // {
    //     if (view.IsMine)
    //     {
    //         // Check if the game has started
    //         if (SceneManager.GetActiveScene().name == sceneMP)
    //         {
    //             if (!isGameStarted)
    //             {
    //                 managePlayerMP(false);
    //             }
    //             else
    //             {
    //                 managePlayerMP(true);
    //             }
    //         }
    //         else
    //         {
    //             if (!isGameStarted)
    //             {
    //                 managePlayer(false);
    //             }
    //             else
    //             {
    //                 managePlayer(true);
    //             }
    //         }
    //     }  
    // }

    [PunRPC]
    private void managePlayer(bool status)
    {
        FindObjectOfType<PlayerMovement>().enabled = status;
    }

    [PunRPC]
    private void managePlayerMP(bool status)
    {
        FindObjectOfType<PlayerMovementMP>().enabled = status;
    }
}
