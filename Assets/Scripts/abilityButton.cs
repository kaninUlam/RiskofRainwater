using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abilityButton : MonoBehaviour
{
    public float MaxDuration = 10f;
    public float duration = 0f;
    public float MaxTimer = 20f;
    public float Timer = 0f;

    GameObject player;
    characterStats stats;
    bool ItemInUse = false;
    bool IsReady = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Vampire V1");
        stats = player.GetComponent<characterStats>();
        Timer = MaxTimer;
        duration = MaxDuration;
    }

    // Update is called once per frame
    void Update()
    {
        ItemInUse = Input.GetKey(KeyCode.E);
        if (Timer >= 0)
        {
            IsReady = false;
            Timer -= Time.deltaTime;
        }
        if (Timer<=0)
        {
            IsReady = true;
            if (ItemInUse == true && IsReady == true)
            {
                stats.isInvincible = true;
                duration -= Time.deltaTime;
                if (duration <= 0)
                {
                    Timer = MaxTimer;
                    stats.isInvincible = false;
                    duration = MaxDuration;
                }
            }
            
        }
    }
}
    
