using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class middleScript : MonoBehaviour
{
    public logicScript logic;
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


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioManager.playSFX(audioManager.point);
        if (collision.gameObject.layer == 3)
        {
            
            logic.addScore();
        }
    }
}
