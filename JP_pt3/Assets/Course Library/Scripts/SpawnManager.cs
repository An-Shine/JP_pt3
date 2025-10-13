using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    
    Vector3 spawnPos = new Vector3(25, 0, 0);
    float startDelay = 2.0f;
    float repeatRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
        
    void SpawnObstacel()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
