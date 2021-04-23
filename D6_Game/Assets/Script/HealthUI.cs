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

    // get a reference variable to the player
    public Player player;

    /* the health UI system has 6 dots in the system
     each dot will turn into white when player lose 1 health point

    The health system in D6 is in whole number, so setting an exact value should be appropriate
    */
    public void HealthUICheck()
    {
        // if the player's health is exactly at 5
        if (player.playerHealth == 5)
        {
            print("decrease health in ui");
            // the first circle in the top will turn white
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
