using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    public Button[] characterButtons;
    public int[] unlockCosts;
    public TextMeshProUGUI availablePattyText;

    private int availablePatty = 0;
    private string gameScene = "";

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the points value and game scene from PlayerPrefs
        int savedPoints = PlayerPrefs.GetInt("Points", 0);
        availablePatty = savedPoints;
        Debug.Log("Available Points: " + availablePatty);
        gameScene = PlayerPrefs.GetString("GameScene", "");

        // Assign the availablePattyText component in the scene to the availablePattyText variable
        availablePattyText.text = savedPoints.ToString();

        // Add click listeners to character selection buttons
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int characterIndex = i;
            characterButtons[i].onClick.AddListener(() => CharacterButtonClicked(characterIndex));
            characterButtons[i].interactable = CanCharacterBeUnlocked(i);
        }

        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();
    }

    // Called when a character selection button is clicked
    public void CharacterButtonClicked(int characterIndex)
    {
        if (CanCharacterBeUnlocked(characterIndex))
        {
            // Store the selected character index in PlayerPrefs
            PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
            PlayerPrefs.Save();

            // Load the game scene based on the selected difficulty level
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.Log("Not enough coins to unlock this character.");
        }
    }

    private bool CanCharacterBeUnlocked(int characterIndex)
    {
        if (characterIndex < unlockCosts.Length)
        {
            int cost = unlockCosts[characterIndex];
            Debug.Log("Character " + characterIndex + " Unlock Cost: " + cost);
            Debug.Log("Available Coins: " + availablePatty);

            if (availablePatty >= cost)
            {
                Debug.Log("Character " + characterIndex + " can be unlocked!");
                return true;
            }
        }

        Debug.Log("Character " + characterIndex + " cannot be unlocked.");
        return false;
    }

    // Set the number of available coins
    public void SetAvailablePatty(int patty)
    {
        availablePatty = patty;
    }
}
