using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public int easyPoints = 1;
    public int mediumPoints = 5;
    public int hardPoints = 10;

    void Start()
    {
        easyButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Easy Level", easyPoints));
        mediumButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Medium Level", mediumPoints));
        hardButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Hard Level", hardPoints));
    }

    public void LevelButtonClicked(string nextScene, string gameScene, int pointValue)
    {
        PlayerPrefs.SetString("GameScene", gameScene);
        PlayerPrefs.SetInt("PointValue", pointValue);
        PlayerPrefs.Save();

        SceneManager.LoadScene(nextScene);
    }

}