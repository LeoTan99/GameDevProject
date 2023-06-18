using UnityEngine;

public class SpawnPlayerTest : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get the selected character index from PlayerPrefs
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Spawn the player object with the selected character
        SpawnPlayerObject(selectedCharacterIndex);
    }

    // Spawn the player object with the selected character
    private void SpawnPlayerObject(int selectedCharacterIndex)
    {
        GameObject playerObject = Instantiate(playerPrefabs[selectedCharacterIndex], spawnPosition.transform.position, Quaternion.identity);
        // Additional setup for the spawned player object (e.g., setting player name)
    }
}
