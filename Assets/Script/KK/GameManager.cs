using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject KrabbyPatty;
    public GameObject[] KrabbyPattySpawnLocation;
    public int spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*int spawnKrabbyPatty;
        spawnKrabbyPatty = Random.Range(0, 100);

        if(spawnKrabbyPatty == 1)
        {
            
            Instantiate(KrabbyPatty, KrabbyPattySpawnLocation[randomSpawnLocation].transform.position, Quaternion.identity);
        }*/

        if (Time.time > spawnTime)
        {
            spawnTime += 5;
            int randomSpawnLocation;
            randomSpawnLocation = Random.Range(0, KrabbyPattySpawnLocation.Length);
            Instantiate(KrabbyPatty, KrabbyPattySpawnLocation[randomSpawnLocation].transform.position, Quaternion.identity);
        }
    }
}
