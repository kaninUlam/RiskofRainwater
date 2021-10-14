using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public float offsetx = 2;
    public float offsety = 2;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x * offsetx, player.transform.position.y * offsety, 76);    
    }
}
