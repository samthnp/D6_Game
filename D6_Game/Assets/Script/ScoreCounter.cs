using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static float scoreValue = 0;
    
    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
        score.GetComponent<Text>().color = Color.magenta;
    }

    private void Update()
    {
        score.text = scoreValue + "/";
    }
}
