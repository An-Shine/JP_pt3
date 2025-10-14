using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    Vector3 spawnPos = new Vector3(25, 0.5f, 0);
    float startDelay = 2.0f;
    float repeatRate = 2.0f;
    PlayerContorller playerControllerscript;
    
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerscript = GameObject.Find("Player").GetComponent<PlayerContorller>();
    }
        
    public void SpawnObstacle()
    {
        if(playerControllerscript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);    
        }        
    }

   
}
