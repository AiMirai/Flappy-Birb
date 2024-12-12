using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public GameObject Pipe;
    public float initialSpawnRate = 8;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset = 10;
    public logicScript logic;
    public float minimumSpawnRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        spawnRate = initialSpawnRate;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    { // Increase timer by Time.deltaTime
        timer += Time.deltaTime;

        // Check if it's time to spawn a new pipe
        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0f; // Reset timer after spawning
        }
        AdjustSpawnRate();
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(Pipe, new Vector3(transform.position.x, UnityEngine.Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
    void AdjustSpawnRate()
    {
        // Get the pipe move speed from the pipeMoveScript
        pipeMoveScript pipeMove = FindObjectOfType<pipeMoveScript>();
        if (pipeMove != null)
        {
            float currentPipeSpeed = pipeMove.moveSpeed;
            spawnRate = Mathf.Max(initialSpawnRate * 8f / currentPipeSpeed, minimumSpawnRate); // Assume base speed is 5
        }

    }
}