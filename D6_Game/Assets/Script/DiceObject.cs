using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private void Start()
    {
        diceGrid = GameObject.FindGameObjectWithTag("DiceGrid");

        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner1.transform.position ||
            this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner1.transform.position)
        {
            isColumn1 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner2.transform.position ||
            this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner2.transform.position)
        {
            isColumn2 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner3.transform.position ||
            this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner3.transform.position)
        {
            isColumn3 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner4.transform.position ||
            this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner4.transform.position)
        {
            isColumn4 = true;
        }
        
        if (this.transform.position == 
            diceGrid.GetComponent<DiceGrid>().upperSpawner5.transform.position ||
            this.transform.position ==
            diceGrid.GetComponent<DiceGrid>().lowerSpawner5.transform.position)
        {
            isColumn5 = true;
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

}
