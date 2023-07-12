using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class SpawnPlayerMP : MonoBehaviourPunCallbacks
{
    public string[] playerName;
    public GameObject[] playerPrefabs;
    //public Vector3[] playerPos;
    public GameObject[] playerPos;
    public Button[] characterSelectionButtons;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < characterSelectionButtons.Length; i++)
        {
            int characterIndex = i; // Capture the index for the callback
            characterSelectionButtons[i].onClick.AddListener(() => OnCharacterSelectionButtonClicked(characterIndex));
        }
    }

    public void OnCharacterSelectionButtonClicked(int index)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            playerName[0] = PhotonNetwork.NickName;
            photonView.RPC("Set_OtherPlayerName", RpcTarget.OthersBuffered, 0, PhotonNetwork.NickName);
            SpawnPlayerWithCharacter(index, playerPos[0].transform.position, playerPos[0].transform.rotation);
        }
        else
        {
            playerName[1] = PhotonNetwork.NickName;
            photonView.RPC("Set_OtherPlayerName", RpcTarget.OthersBuffered, 1, PhotonNetwork.NickName);
            Quaternion rotationB = Quaternion.Euler(0f, 180f, 0f);
            SpawnPlayerWithCharacter(index, playerPos[1].transform.position, playerPos[1].transform.rotation);
        }

        // Disable the canvas game object
        characterSelectionButtons[index].transform.parent.gameObject.SetActive(false);
    }

    void SpawnPlayerWithCharacter(int characterIndex, Vector3 position, Quaternion rotation)
    {
        GameObject selectedCharacterPrefab = playerPrefabs[characterIndex];
        GameObject playerObject = PhotonNetwork.Instantiate(selectedCharacterPrefab.name, position, rotation);
       /* UpdatePlayerName(playerObject, playerName[characterIndex]);*/
    }

/*    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter");

        if (PhotonNetwork.IsMasterClient)
        {
            playerName[0] = PhotonNetwork.NickName;
            photonView.RPC("Set_OtherPlayerName", RpcTarget.OthersBuffered, 0, PhotonNetwork.NickName);
            PhotonNetwork.Instantiate(playerPrefabs[selectedCharacterIndex].name, playerPos[0], Quaternion.identity);
            //Transform canvas = player.transform.Find("Canvas");
            //Transform showName = canvas.Find("Name");
            //showName.GetComponent<TextMeshProUGUI>().text = playerName[0];
        }
        else
        {
            playerName[1] = PhotonNetwork.NickName;
            photonView.RPC("Set_OtherPlayerName", RpcTarget.OthersBuffered, 1, PhotonNetwork.NickName);
            Quaternion rotationB = Quaternion.Euler(0f, 180f, 0f);
            PhotonNetwork.Instantiate(playerPrefabs[selectedCharacterIndex].name, playerPos[1], rotationB);
            //Transform canvas = player.transform.Find("Canvas");
            //Transform showName = canvas.Find("Name");
            //showName.GetComponent<TextMeshProUGUI>().text = playerName[1];
        }
    }*/

    [PunRPC]
    void Set_OtherPlayerName(int index, string name)
    {
        playerName[index] = name;
    }
}
