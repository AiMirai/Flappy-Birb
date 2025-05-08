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
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManage>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;
        }
        if (transform.position.y < fallthreshold || transform.position.y > maxheight)
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
}
