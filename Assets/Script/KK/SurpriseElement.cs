using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseElement : MonoBehaviour
{
    public GameObject opponent;
    [SerializeField] private AudioSource SoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        opponent = GameObject.FindGameObjectWithTag("Squidward");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator freezingOpponent()
    {
        opponent.GetComponent<AiOpponent>().enabled = false;
        opponent.transform.GetChild(5).gameObject.SetActive(true);

        yield return new WaitForSeconds(5f);
        opponent.GetComponent<AiOpponent>().enabled = true;
        opponent.transform.GetChild(5).gameObject.SetActive(false);
    }

    IEnumerator speedUp()
    {
        gameObject.GetComponent<PlayerMovement>()._playerSpeed = 35f;

        yield return new WaitForSeconds(5f);

        gameObject.GetComponent<PlayerMovement>()._playerSpeed = 20f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KrabbyPatty")
        {
            int dice;
            dice = Random.Range(0, 2);
            if(dice == 0)
            {
                StartCoroutine(freezingOpponent());
                
            }
            else if(dice == 1)
            {
                StartCoroutine(speedUp());
            }

            print("dice = " + dice);
            SoundEffect.Play();
            Destroy(other.gameObject);
        }
    }
}
