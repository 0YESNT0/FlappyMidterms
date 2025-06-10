using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    [SerializeField]private GameObject[] Trunks;    
    [SerializeField]private float movementSpeed = 6;
    [SerializeField]private float spawnInterval = 3;
    private float currentSpawnCountdown;
    private bool GameStarted = false;

    void OnEnable()
    {
        BirbScript.Start += StartSpawning;
        BirbScript.Dead += StopSpawning;
    }
    // Update is called once per frame
    void Update()
    {

        if(currentSpawnCountdown <= 0){
            //do spawning
            SpawnTrunk();
            currentSpawnCountdown = spawnInterval;
        }
        currentSpawnCountdown -= Time.deltaTime;
    }

    private void SpawnTrunk(){        
        int random = Random.Range(0,Trunks.Count()-1);
        Instantiate(Trunks[random],this.transform);
        Debug.Log("Spawned Trunk");
    }
    private void StartSpawning(){
        Debug.Log("Start spawn");
        GameStarted = true;
    }
    private void StopSpawning(){
        GameStarted = false;
    }
}
