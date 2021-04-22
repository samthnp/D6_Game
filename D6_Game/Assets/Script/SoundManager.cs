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
    
    public AudioClip victorySound;

    public AudioClip gameOverSound;

    public float audioVolume = 0.5f;
    
    // functions to play sound individually
    // there are 6 different sound for when getting score
    // two more sound for when player lose health and discarding
    public void PlayConditionMetSound1()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound1, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayConditionMetSound2()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound2, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayConditionMetSound3()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound3, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayConditionMetSound4()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound4, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayConditionMetSound5()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound5, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayConditionMetSound6()
    {
        AudioSource.PlayClipAtPoint(conditionMetSound6, Camera.main.transform.position, audioVolume);
    }

    public void PlayWrongConditionSound()
    {
        AudioSource.PlayClipAtPoint(wrongCondition, Camera.main.transform.position, audioVolume);
    }

    public void PlayDiscardSound()
    {
        AudioSource.PlayClipAtPoint(discardDice, Camera.main.transform.position, audioVolume);
    }

    // not sure if we need to do a victory or game over scene or not?
    public void PlayVictorySound()
    {
        AudioSource.PlayClipAtPoint(discardDice, Camera.main.transform.position, audioVolume);
    }
    
    public void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(discardDice, Camera.main.transform.position, audioVolume);
    }
}
