using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    // Start is called before the first frame update
    void Start()
    {
        // Add click listeners to level selection buttons
        easyButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Easy Level"));
        mediumButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Medium Level"));
        hardButton.onClick.AddListener(() => LevelButtonClicked("Character Selection", "Hard Level"));
    }

    // Called when a level selection button is clicked
    public void LevelButtonClicked(string nextScene, string gameScene)
    {
        // Store the selected game scene in PlayerPrefs
        PlayerPrefs.SetString("GameScene", gameScene);
        PlayerPrefs.Save();

        // Load the character selection scene
        SceneManager.LoadScene(nextScene);
    }
}