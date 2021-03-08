using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour

{
    private float rangeX = 20.0f;
    private float rangeZ = 18.0f;
    private float startDelay = 2.0f;
    private float repeatDelay = 5.0f;

    // Start is called before the first frame update

    public GameObject ballPrefab; 
    void Start()
    {
        // calling function SpanBall to spawn ball at random position every 5 seconds. First ball is spawned in 2 seconds.
        InvokeRepeating("SpawnBall", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
     

    }
    //generate random x and z coordinates from the given range.  
    private Vector3 GenerateRandomPosition()
    {
    float spawnX = Random.Range(-rangeX, rangeX);
    float spawnZ = Random.Range(-rangeZ, rangeZ);
    Vector3 randomPos = new Vector3(spawnX, 1, spawnZ);
    return randomPos;
}

    //function that generates ball at random position. Rotation 0.0.0
    private void SpawnBall()
    {
        Instantiate(ballPrefab, GenerateRandomPosition(), Quaternion.identity);
    }
}
