using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterStats : MonoBehaviour
{

    // health and jump for character
    public int maxHealth = 100;
    public int CurrentHealth;
    public int JumpNum = 2;

    public healthBar Healthbar;

    // movement variables
    public float Speed = 10f;
    public float JumpHeight = 8f;
    Rigidbody2D rb2d;

    // checks for character
    bool IsAlive = true;
    bool IsJumping = false;
    bool IsGrounded = true;
    public bool isInvincible = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // pressing A and D on the keyboard will move character on the x axis from left to right respectively.
        transform.position = transform.position + new Vector3(-horizontalInput * Time.deltaTime * Speed, 0, 0);

        if (horizontalInput < 0) // when character moves left sprite will face towards the left
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        if (horizontalInput > 0)// when character moves right sprite will face towards the right
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpNum >= 1) // pressing spacebar will make the character jump up in the y axis
        {
            rb2d.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            JumpNum--;
            IsJumping = true;
            IsGrounded = false;
        }
    }
    public void AliveCheck()
    {
        if (CurrentHealth <= 0)
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "platform") // resets the number of jumps when touching the platform
        {
            IsGrounded = true;
            IsJumping = false;
            JumpNum = 2;
        }
    }
}
