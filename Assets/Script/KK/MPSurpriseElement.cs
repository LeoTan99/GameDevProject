using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPSurpriseElement : MonoBehaviour
{
    //public GameObject opponent;
    [SerializeField] private AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        //opponent = GameObject.FindGameObjectWithTag("AIOpponent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator speedUp()
    {
        gameObject.GetComponent<PlayerMovementMP>()._playerSpeed = 35f;

        yield return new WaitForSeconds(5f);

        gameObject.GetComponent<PlayerMovementMP>()._playerSpeed = 20f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KrabbyPatty")
        {
            
            StartCoroutine(speedUp());
            
            SoundEffect.Play();
            Destroy(other.gameObject);
        }
    }
}
