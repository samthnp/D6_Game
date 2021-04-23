using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // get reference to the slider
    private Slider slider;

    // set the default filling speed of the slider when adjusted
    public float fillingSpeed = 500;

    // a target process for filling the bar
    private float targetProgress = 0;
    
    private void Awake()
    {
        // get a reference to the slider
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
        // if the value is less than the target process
        if (slider.value < targetProgress)
            // fill in the bar with assigned speed and time
            slider.value = slider.value + fillingSpeed * Time.deltaTime;
    }
    
    // add progress to the progress bar
    public void IncreaseProgress(float newProgress)
    {
        // add the value of the progress
        targetProgress = slider.value + newProgress;
    }

    // reset bar for when the scene is reloaded
    public void ResetBar()
    {
        // reset value to zero
        slider.value = 0;
    }
}
