using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject : MonoBehaviour
{

    public string diceColor;

    public int diceNumberValue;

    public bool diceIsFocused = false;


    public void CallDiceIsNowFocused()
    {
        Invoke("DiceIsNowFocused", 0.5f);
    }
    public void DiceIsNowFocused()
    {
        diceIsFocused = true;
    }

}
