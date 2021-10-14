using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // sets duration for each item
    public float DurationItemHealth = 10f;
    public float DurationItemSpeed = 10f;
    public float DurationItemInvincible = 10f;

    // adjust the boost that the player will get
    public float SpeedIncrease = 10f;
    public int Healthboost = 20;

    // make things global
    public ItemCheck Item = null;
    public GameObject Player; 
    public characterStats stats;

    // for enum things
    public Items myItem = Items.Health;
    // Start is called before the first frame update
    void Start()
    {
        // sets gameobject to something
        Item = GetComponent<ItemCheck>();
        Player = GameObject.Find("New Sprite");
        stats = Player.GetComponent<characterStats>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // starts coroutine for pickup
        StartCoroutine("pickup");
    }
    IEnumerator pickup()
    {
        switch (myItem) // switch for items 
        {
            // in the case of item pick up is health
            case Items.Health: 
                stats.maxHealth += Healthboost;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                yield return new WaitForSeconds(DurationItemHealth);
                stats.maxHealth -= Healthboost;
                Destroy(this.gameObject);
                break;

            // in the case of item pick up is speed
            case Items.Speed:
                stats.Speed += SpeedIncrease;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                yield return new WaitForSeconds(DurationItemSpeed);
                stats.Speed -= SpeedIncrease;
                Destroy(this.gameObject);
                break;

            // in the case of item pick up is invincible
            case Items.Invincible:
                stats.isInvincible = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                yield return new WaitForSeconds(DurationItemInvincible);
                stats.isInvincible = false;
                Destroy(this.gameObject);
                break;
        }
        
    }
}
