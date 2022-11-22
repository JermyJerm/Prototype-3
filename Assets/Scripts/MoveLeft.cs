using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 6;
    private float RepeatBackgroundSpeed = 30;
    private PlayerController playerControllerScript;
    private float leftBound = -15;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (playerControllerScript.gameOver == false && gameObject.CompareTag("BackGround"))
        {
            transform.Translate(Vector3.right * Time.deltaTime * RepeatBackgroundSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
