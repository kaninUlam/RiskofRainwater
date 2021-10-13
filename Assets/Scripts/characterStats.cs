﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour
{
    public int Health = 100;
    public int JumpNum = 2;
    

    public float Speed = 10f;
    public float JumpHeight = 8f;
    Rigidbody2D rb2d;

    bool IsAlive = true;
    bool IsJumping = false;
    bool IsGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position = transform.position + new Vector3(horizontalInput * Time.deltaTime * Speed, 0, 0);

        if (horizontalInput < 0)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (horizontalInput > 0)
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown("space") && JumpNum >= 1)
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            JumpNum--;
            IsJumping = true;
            IsGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            IsGrounded = true;
            IsJumping = false;
            JumpNum = 2;
        }
    }
}
