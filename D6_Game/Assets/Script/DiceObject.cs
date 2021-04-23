using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceObject : MonoBehaviour
{
    // variable to store the value of color fo each dice
    public string diceColor;

    // variable to store the number value
    public int diceNumberValue;

    // a boolean variable too indicate if the dice is still in the grid or in focus
    public bool diceIsFocused = false;

    // a boolean variable that identify which column they belong to. They're used as soon as the dice is spawned
    public bool isColumn1 = false;
    public bool isColumn2 = false;
    public bool isColumn3 = false;
    public bool isColumn4 = false;
    public bool isColumn5 = false;

    // a GameObject reference to the diceGrid class in the game world
    public GameObject diceGrid;

    // a boolean variable is communicate with the Player class when it is clicked and on the move to the focus section
    public bool diceIsOutOfGrid;
    
    private void Start()
    {
        // find the grid object to make a reference and store it as variable
        diceGrid = GameObject.FindGameObjectWithTag("DiceGrid");

        // when the object is spawned set which column it belongs to
        // since the dice always spawn according to the grid, it's possible to set the value accurately
        
        /* dice spawn in the column1 transform will be marked as belong to column1
         this will go on until the last column which is column5 */

        // in this first condition if
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

    // update to ensure that during their movement, no dice is set into a different column with the isColumn variables
    private void Update()
    {
        // if they are out of grid, make sure to mark them all as a dice without any reference to the column
        if (diceIsOutOfGrid == true)
        {
            isColumn1 = false;
            isColumn2 = false;
            isColumn3 = false;
            isColumn4 = false;
            isColumn5 = false;
        }
    }

    // player access this function when clicking on dice, it will change the dice into focus
    public void CallDiceIsNowFocused()
    {
        Invoke("DiceIsNowFocused", 0.5f);
    }
    
    // this function will be called after a short delay to ensure it's not changed immediately and conflict with the dice refill system
    public void DiceIsNowFocused()
    {
        diceIsFocused = true;
    }
    

}
