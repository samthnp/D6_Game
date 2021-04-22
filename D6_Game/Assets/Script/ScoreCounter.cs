using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static float scoreValue = 0;
    
    private Text score;

    // start the text with the selected color
    private void Start()
    {
        score = GetComponent<Text>();
        score.GetComponent<Text>().color = Color.magenta;
    }

    // whenever player received a score, update the UI
    private void Update()
    {
        score.text = scoreValue + "/";
    }
}
