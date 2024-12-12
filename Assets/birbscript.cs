using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birbscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public logicScript logic;
    public bool birdIsAlive = true;
    public float fallthreshold = -35;
    public float maxheight = 42;
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
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;
        }
        if (transform.position.y < fallthreshold || transform.position.y > maxheight)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.playSFX(audioManager.death);
        logic.gameOver();
        birdIsAlive = false;
    }
 
}
