using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject : MonoBehaviour
{

    public string diceColor;

    public int diceNumberValue;

    public bool diceIsFocused = false;
    
    private bool isUpperDice = false;
    private bool isLowerDice = false;
    private bool isHiddenDice = false;

    private void Start()
    {
        
        /*
        if ()
        {
            isUpperDice = true;
        }

        if ()
        {
            isLowerDice = true;
        }

        if ()
        {
            isHiddenDice = true;
        }
        */
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
