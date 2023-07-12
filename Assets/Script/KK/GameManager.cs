using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject KrabbyPatty;
    public GameObject[] KrabbyPattySpawnLocation;
    public int spawnTime;
    private int saveSpawnTime;
    public GameObject[] box;

    // Start is called before the first frame update
    void Start()
    {
        saveSpawnTime = spawnTime;
        destroyBurger();
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
            spawnTime += saveSpawnTime;
            int randomSpawnLocation;
            randomSpawnLocation = Random.Range(0, KrabbyPattySpawnLocation.Length);
            Instantiate(KrabbyPatty, KrabbyPattySpawnLocation[randomSpawnLocation].transform.position, Quaternion.identity);
        }
    }

    public void destroyBurger()
    {
        print("destroying");
        box = GameObject.FindGameObjectsWithTag("KrabbyPatty");

        foreach (GameObject obj in box)
        {
            Destroy(obj);
        }
    }
}
