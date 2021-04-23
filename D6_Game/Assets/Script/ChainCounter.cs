using System;
using UnityEngine;
using UnityEngine.UI;

public class ChainCounter : MonoBehaviour
{
    // default value of the chain point is zero
    public static float chainValue = 0;
    
    // a variable type of Text assigned to the chain points
    private Text chain;

    private void Start()
    {
        // set the text to a specified color
        chain = GetComponent<Text>();
        chain.GetComponent<Text>().color = Color.magenta;
    }

    private void Update()
    {
        // update the value of the chain point in the text
        chain.text = chainValue + "";
    }
}