using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<MoveAroundObject>().setCamera(transform.GetChild(3).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
