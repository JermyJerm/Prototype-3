﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    private Animator playerAnim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    public bool isOnGround = true;
    public bool midAir = true;
    int delayTime = 1;
    private float xtraDelay = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
           playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
           isOnGround = false;
           midAir = true;
           playerAnim.SetTrigger("Jump_Trig");
        }

        if (Input.GetKey(KeyCode.Z) && midAir)
        {
            playerRb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            midAir = false;
            playerAnim.SetTrigger("Jump_Trig");
        }
    }
    
    public bool gameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
