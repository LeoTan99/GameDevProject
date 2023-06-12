using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class SpawnPlayerMP : MonoBehaviourPunCallbacks
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

        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("SetSelectedCharacterIndex", RpcTarget.AllBuffered, selectedCharacterIndex);
        }

        // Spawn the player object with the selected character
        if (PhotonNetwork.IsMasterClient)
        {
            SpawnPlayerObject(playerPos[0], Quaternion.identity);
        }
        else
        {
            Quaternion rotationB = Quaternion.Euler(0f, 180f, 0f);
            SpawnPlayerObject(playerPos[1], rotationB);
        }

        // Disable the canvas containing the button
        characterButtons[characterIndex].transform.parent.gameObject.SetActive(false);
    }


    // Spawn the player object with the selected character
    private void SpawnPlayerObject(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        GameObject playerObject = PhotonNetwork.Instantiate(playerPrefabs[selectedCharacterIndex].name, spawnPosition, spawnRotation);
        // UpdatePlayerName(playerObject, PhotonNetwork.NickName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [PunRPC]
    void SetPlayerInfo(string playerName, int characterIndex)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            playerName = playerName.Trim();
            playerName = playerName.Substring(0, Mathf.Min(playerName.Length, 10)); // Limit the player name to 10 characters
            PhotonNetwork.NickName = playerName;
        }

        selectedCharacterIndex = characterIndex;
    }

    [PunRPC]
    void SetSelectedCharacterIndex(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;
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