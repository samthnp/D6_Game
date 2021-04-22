using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    private Slider slider;

    public float fillingSpeed = 500;

    private float targetProgress = 0;
    
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // start with 0 progression
    private void Start()
    {
        slider.value = 0;
    }

    // update the bar according to the score received
    private void Update()
    {
        if (slider.value < targetProgress)
            slider.value = slider.value + fillingSpeed * Time.deltaTime;
    }
    
    // add progress to the progress bar
    public void IncreaseProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    // reset bar for when the scene is reloaded
    public void ResetBar()
    {
        slider.value = 0;
    }
}
