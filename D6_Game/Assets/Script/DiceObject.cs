using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceObject : MonoBehaviour
{

    public string diceColor;

    public int diceNumberValue;

    public bool diceIsFocused = false;

    public bool isColumn1 = false;
    public bool isColumn2 = false;
    public bool isColumn3 = false;
    public bool isColumn4 = false;
    public bool isColumn5 = false;

    public GameObject diceGrid;

    public bool diceIsOutOfGrid;

    public Animator diceAnimator;
    
    private void Start()
    {
        diceGrid = GameObject.FindGameObjectWithTag("DiceGrid");

        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner1.transform.position &&
            diceIsOutOfGrid == false
            
            ||
            
            (this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner1.transform.position) &&
            diceIsOutOfGrid == false)
        {
            isColumn1 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner2.transform.position &&
            diceIsOutOfGrid == false
            
            ||
            
            (this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner2.transform.position) &&
            diceIsOutOfGrid == false)
        {
            isColumn2 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner3.transform.position &&
            diceIsOutOfGrid == false
            
            ||
            
            (this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner3.transform.position) &&
            diceIsOutOfGrid == false)
        {
            isColumn3 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner4.transform.position && 
            diceIsOutOfGrid == false
            
            ||
            
            (this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner4.transform.position) &&
            diceIsOutOfGrid == false)
        {
            isColumn4 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner5.transform.position &&
            diceIsOutOfGrid == false
            
            ||
            
            (this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner5.transform.position) &&
            diceIsOutOfGrid == false)
        {
            isColumn5 = true;
        }
    }

    private void Update()
    {
        if (diceIsOutOfGrid == true)
        {
            isColumn1 = false;
            isColumn2 = false;
            isColumn3 = false;
            isColumn4 = false;
            isColumn5 = false;
        }
    }

    public void CallDiceIsNowFocused()
    {
        Invoke("DiceIsNowFocused", 0.5f);
    }
    public void DiceIsNowFocused()
    {
        diceIsFocused = true;
    }

    public void PlayDiceShake()
    {
        diceAnimator.SetTrigger("TriggerShake");
        print("Play Shake");
    }

}
