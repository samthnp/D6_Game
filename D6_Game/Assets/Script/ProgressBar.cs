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

    private void Start()
    {
        slider.value = 0;
    }

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

    public void ResetBar()
    {
        slider.value = 0;
    }
}
