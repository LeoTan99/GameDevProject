using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Array of player prefabs for different characters
    public Vector3[] playerPos;
    private int selectedCharacterIndex = 0; // Index of the selected character

    public Button[] characterButtons; // Array of character selection buttons

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
        }
    }


    // Called when a character selection button is clicked
    public void CharacterButtonClicked(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;

        // Spawn the player object with the selected character
        SpawnPlayerObject(playerPos[0], Quaternion.identity);

        // Disable the canvas containing the button
        characterButtons[characterIndex].transform.parent.gameObject.SetActive(false);
    }


    // Spawn the player object with the selected character
    private void SpawnPlayerObject(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        GameObject playerObject = Instantiate(playerPrefabs[selectedCharacterIndex], spawnPosition, spawnRotation);
        // UpdatePlayerName(playerObject, "Player Name"); // Set a default name for the player
    }

    // Update is called once per frame
    void Update()
    {

    }

    // private void UpdatePlayerName(GameObject playerObject, string name)
    // {
    //     if (playerObject != null)
    //     {
    //         Transform canvas = playerObject.transform.Find("Canvas");
    //         Transform showName = canvas.Find("Name");
    //         showName.GetComponent<TextMeshProUGUI>().text = name;
    //     }
    // }
}