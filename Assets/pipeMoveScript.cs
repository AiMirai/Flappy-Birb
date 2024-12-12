using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed;
    float deadZone = -60;
    float speedIncrease = 0.1f;
    public logicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustMoveSpeed();

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        void AdjustMoveSpeed()
        {
            // Get the player score from the logic script
            int playerScore = logic.getScore();

            // Adjust the move speed based on the player score (example: increase by speedIncrease for each point)
            moveSpeed = 9f + (playerScore * speedIncrease);

        }

    }
}
