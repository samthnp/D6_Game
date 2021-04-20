using System;
using UnityEngine;
using UnityEngine.UI;

public class ChainCounter : MonoBehaviour
{
    public static float chainValue = 0;
    
    private Text chain;

    private void Start()
    {
        chain = GetComponent<Text>();
    }

    private void Update()
    {
        chain.text = chainValue + " CHAIN";
    }
}