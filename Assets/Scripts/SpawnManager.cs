using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    PlayerControllerMovement transformPos;
    public int maxCapsule = 20;
    public int maxBomb = 5;
    int randomNum;
    int randomBomb;

    [Header("Prefabs")]
/*    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;*/
    GameObject choosenCapsule;
    GameObject spawnBomb;
    public GameObject[] capsules;
    public GameObject[] bombs;
    

    void Start()
    {
        transformPos = GameObject.Find("Player").GetComponent<PlayerControllerMovement>();
       // capsules = GameObject.FindGameObjectsWithTag("Capsule");

        spawnCapsule();
    }

    void spawnCapsule()
    {
        for (int i = 0; i < maxCapsule; i++)
        {
            Vector3 spawnPosCapsules = new Vector3(Random.Range(-transformPos.xRange, transformPos.xRange), 0, Random.Range(-transformPos.zRange, transformPos.zRange));

            randomNum = Random.Range(0, capsules.Length);
            choosenCapsule = capsules[randomNum];
            Instantiate(choosenCapsule, spawnPosCapsules, Quaternion.identity);
        }
        for (int j = 0; j < maxBomb; j++)
        {
            Vector3 spawnPosBombs = new Vector3(Random.Range(-transformPos.xRange, transformPos.xRange), 0, Random.Range(-transformPos.zRange, transformPos.zRange));
            randomBomb = Random.Range(0, bombs.Length);
            spawnBomb = bombs[randomBomb];
            Instantiate(spawnBomb, spawnPosBombs, Quaternion.identity);

        }
       
    }

}
