using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainDetectnDmg : MonoBehaviour
{
    Rigidbody2D rb2D; // rigidbody2d

    public int damage = 1;
    public GameObject player;
    public characterStats stats;
    public healthBar Healthbar;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false; // stops the raycast from detecting the collider from the point of origin
        player = GameObject.Find("Vampire V1"); // access the gameobject player ** change the New Sprite to name of character sprite
        stats = player.GetComponent<characterStats>(); // access the characterstats
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up); // sets up the raycast 2d

        if (hit.collider != null) // checks if raycast collides with an object
        {
            if(hit.collider.gameObject.tag == "Player" && stats.isInvincible == false) // if player is hit and is not invincible
            {
                Debug.Log(stats.CurrentHealth);
                stats.CurrentHealth -= damage; // decreases health using time.deltatime 
                Healthbar.SetHealth(stats.CurrentHealth);
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red); // draws line
            }
            if (hit.collider.gameObject.tag == "Player" && stats.isInvincible == true) // if player is hit and is invincible
            {
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.red); // draws line
            }
            if (hit.collider.gameObject.tag == "platform") // if platform is hit
            {
                Debug.DrawLine(gameObject.transform.position, hit.point, Color.green); // draws line
                Debug.Log("not hit");
            }
        }
    }
}
