using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    // set the default value of the score to zero
    public static float scoreValue = 0;
    
    // create a 
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
        // update the score value UI
        score.text = scoreValue + "/";
    }
}
