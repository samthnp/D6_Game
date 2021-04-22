using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // get the reference to each child gameObject to manipulate their color on the spriteRenderer
    public GameObject circle1;
    public GameObject circle2;
    public GameObject circle3;
    public GameObject circle4;
    public GameObject circle5;

    public Player player;

    // the health UI system has 6 dots in the system
    // each dot will turn into white when player lose 1 health point
    public void HealthUICheck()
    {
        if (player.playerHealth == 5)
        {
            print("decrease health in ui");
            circle1.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (player.playerHealth == 4)
        {
            circle2.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (player.playerHealth == 3)
        {
            circle3.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (player.playerHealth == 2)
        {
            circle4.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
        if (player.playerHealth == 1)
        {
            circle5.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
}
