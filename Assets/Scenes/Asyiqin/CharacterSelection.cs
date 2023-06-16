using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button[] characterButtons; // Array of character selection buttons
    public int[] unlockCosts; // Array of patty costs to unlock each character

    public static int selectedCharacterIndex = 0; // Index of the selected character
    private int availableCoins = 0; // Number of available coins

    // Start is called before the first frame update
    void Start()
    {
        // Add click listeners to character selection buttons
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int characterIndex = i; // Capture the current index in a local variable

            // Check if the button already has the event listener
            if (!(characterButtons[i].onClick.GetPersistentEventCount() > 0))
            {
                characterButtons[i].onClick.AddListener(() => CharacterButtonClicked(characterIndex));
            }

            // Set the button interactability based on unlock status
            characterButtons[i].interactable = CanCharacterBeUnlocked(i);
        }

        // Retrieve the points value from PlayerPrefs
        int savedPoints = PlayerPrefs.GetInt("Points", 0);
        availableCoins = savedPoints;
        Debug.Log("Available Coins: " + availableCoins);

        // Reset the points value to zero in PlayerPrefs
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();
    }

    // Called when a character selection button is clicked
    public void CharacterButtonClicked(int characterIndex)
    {
        if (CanCharacterBeUnlocked(characterIndex))
        {
            selectedCharacterIndex = characterIndex;

            // Load the scene where the player will spawn
            SceneManager.LoadScene("GameTesting");
        }
        else
        {
            Debug.Log(availableCoins);
            Debug.Log("Not enough coins to unlock this character.");
        }
    }

    // Check if a character can be unlocked based on its unlock cost
    private bool CanCharacterBeUnlocked(int characterIndex)
    {
        if (characterIndex < unlockCosts.Length)
        {
            int cost = unlockCosts[characterIndex];
            return availableCoins >= cost;
        }

        return false;
    }

    // Set the number of available coins
    public void SetAvailableCoins(int coins)
    {
        availableCoins = coins;
    }
}
