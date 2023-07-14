using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraSetup : MonoBehaviour
{
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            FindAnyObjectByType<MoveAroundObject>().setCamera(transform.GetChild(3).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
