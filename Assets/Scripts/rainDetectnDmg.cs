using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainDetectnDmg : MonoBehaviour
{
    Rigidbody2D rb2D; // rigidbody2d
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false; // stops the raycast from detecting the collider from the point of origin
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up); // sets up the raycast 2d

        if (hit.collider != null) // checks if raycast collides with an object
        {
            if(hit.collider.gameObject.tag == "Player") // if player is hit
            {
                GameObject player = GameObject.Find("New Sprite"); // access the gameobject player ** change the New Sprite to name of character sprite
                characterStats stats = player.GetComponent<characterStats>(); // access the characterstats
                Debug.Log(stats.maxHealth);
                stats.maxHealth -= Time.deltaTime * 2; // decreases health using time.deltatime
                
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red); // draws line
            }
            if(hit.collider.gameObject.tag == "platform") // if platform is hit
            {
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.green); // draws line
                Debug.Log("not hit");
            }
        }
    }
}
