using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enum for items 
public enum Items { Health, Speed, Invincible }

public class ItemCheck : MonoBehaviour
{
    public Items myItem = Items.Health;
}
