using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 30;
    float leftBound = -15;
    PlayerContorller playerControllerScript;

    
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerContorller>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
