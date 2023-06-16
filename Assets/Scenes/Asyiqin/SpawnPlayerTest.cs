using UnityEngine;

public class SpawnPlayerTest : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Array of player prefabs for different characters
    public Vector3 spawnPosition; // Spawn position for the character

    // Start is called before the first frame update
    void Start()
    {
        // Get the selected character index from the CharacterSelection script
        int selectedCharacterIndex = CharacterSelection.selectedCharacterIndex;

        // Spawn the player object with the selected character
        SpawnPlayerObject(selectedCharacterIndex);
    }

    // Spawn the player object with the selected character
    private void SpawnPlayerObject(int selectedCharacterIndex)
    {
        GameObject playerObject = Instantiate(playerPrefabs[selectedCharacterIndex], spawnPosition, Quaternion.identity);
        // Additional setup for the spawned player object (e.g., setting player name)
    }
}
