using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public GameObject Pipe;
    public float initialSpawnRate = 10;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset = 10;
    public logicScript logic;
    public float minimumSpawnRate = 0.5f;

    private bool isSpawning = false; // NEW

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        spawnRate = initialSpawnRate;

        // No pipe spawn at start
    }

    void Update()
    {
        if (!isSpawning) return; // Skip spawning logic if game hasn't started

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            spawnPipe();
            timer = 0f;
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
        pipeMoveScript pipeMove = FindObjectOfType<pipeMoveScript>();
        if (pipeMove != null)
        {
            float currentPipeSpeed = pipeMove.moveSpeed;
            spawnRate = Mathf.Max(initialSpawnRate / (1f + (currentPipeSpeed - 1f) * 0.4f), minimumSpawnRate);
        }
    }

    public void StartSpawning() // NEW
    {
        isSpawning = true;
        spawnPipe();     // Spawn first pipe immediately
        timer = 0f;      // Reset timer so next pipe comes after full spawnRate
    }
}
