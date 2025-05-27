using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birbscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public logicScript logic;
    public bool birdIsAlive = true;
    private bool deathHandled = false;
    public float fallthreshold = -42;
    public float maxheight = 45;
    audioManage audioManager;

    private bool gameStarted = false;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManage>();
        myRigidbody.simulated = false; // Disable gravity until game starts
    }

    void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            StartGame();
        }
        else if (gameStarted && birdIsAlive && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)))
        {
            myRigidbody.linearVelocity= Vector2.up * flapStrenght;
        }

        if (gameStarted && (transform.position.y < fallthreshold || transform.position.y > maxheight))
        {
            HandleDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        if (deathHandled) return;

        deathHandled = true;
        birdIsAlive = false;

        audioManager.playSFX(audioManager.death);
        logic.gameOver();
    }

    private void StartGame()
    {
        logic.HideStartText();
        gameStarted = true;
        myRigidbody.simulated = true;
        myRigidbody.linearVelocity = Vector2.up * flapStrenght;

        GameObject.FindGameObjectWithTag("PipeSpawner")
            .GetComponent<pipeSpawner>()
            .StartSpawning(); // <-- Start spawning pipes now
    }
}
