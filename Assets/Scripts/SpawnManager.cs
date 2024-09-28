using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animalPrefabs = new GameObject[3];
    [SerializeField]
    private GameObject[] sideAnimalPrefabs = new GameObject[1];
    [SerializeField]
    private GameObject player;

    private float spawnRangeX = 10f;
    private float spawnposX = 20f;
    private float spawnposMaxZ = 30f;
    private float spawnposMinZ = 5f;

    private float startDelay = 2f;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
            InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
            InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        if (player.activeInHierarchy)
        {
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            Vector3 spawnpos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnposMaxZ);
            Instantiate(animalPrefabs[animalIndex], spawnpos, animalPrefabs[animalIndex].transform.rotation);
        }
    }

    void SpawnRightAnimal()
    {
        Vector3 rotation = new Vector3(0, -90, 0);
        if (player.activeInHierarchy)
        {
            Vector3 spawnpos = new Vector3(spawnposX, 0, Random.Range(spawnposMinZ, spawnposMaxZ));
            Instantiate(sideAnimalPrefabs[0], spawnpos, Quaternion.Euler(rotation));
        }
    }

    void SpawnLeftAnimal()
    {
        Vector3 rotation = new Vector3(0, 90, 0);
        if (player.activeInHierarchy)
        {
            Vector3 spawnpos = new Vector3(-spawnposX, 0, Random.Range(spawnposMinZ, spawnposMaxZ));
            Instantiate(sideAnimalPrefabs[0], spawnpos, Quaternion.Euler(rotation));
        }
    }
}
