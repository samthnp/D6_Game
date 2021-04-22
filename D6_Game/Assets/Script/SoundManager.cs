using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip conditionMetSound1;
    public AudioClip conditionMetSound2;
    public AudioClip conditionMetSound3;
    public AudioClip conditionMetSound4;
    public AudioClip conditionMetSound5;
    public AudioClip conditionMetSound6;

    public AudioClip wrongCondition;

    public AudioClip discardDice;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            playConditionMetSound1();
        }
        
        if (Input.GetKeyUp(KeyCode.X))
        {
            playConditionMetSound2();
        }
        
        if (Input.GetKeyUp(KeyCode.C))
        {
            playConditionMetSound3();
        }
        
        if (Input.GetKeyUp(KeyCode.V))
        {
            playConditionMetSound4();
        }
        
        if (Input.GetKeyUp(KeyCode.B))
        {
            playConditionMetSound5();
        }
        
        if (Input.GetKeyUp(KeyCode.N))
        {
            playConditionMetSound6();
        }
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            playWrongConditionSound();
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playDiscardSound();
        }
    }

    public void playConditionMetSound1()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound1, Camera.main.transform.position, 0.1f);
    }
    
    public void playConditionMetSound2()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound2, Camera.main.transform.position, 0.1f);
    }
    
    public void playConditionMetSound3()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound3, Camera.main.transform.position, 0.1f);
    }
    
    public void playConditionMetSound4()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound4, Camera.main.transform.position, 0.1f);
    }
    
    public void playConditionMetSound5()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound5, Camera.main.transform.position, 0.1f);
    }
    
    public void playConditionMetSound6()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound6, Camera.main.transform.position, 0.1f);
    }

    public void playWrongConditionSound()
    {
        AudioSource.PlayClipAtPoint(wrongCondition, Camera.main.transform.position, 0.1f);
    }

    public void playDiscardSound()
    {
        AudioSource.PlayClipAtPoint(discardDice, Camera.main.transform.position, 0.1f);
    }
}
