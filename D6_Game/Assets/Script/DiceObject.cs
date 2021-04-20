using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceObject : MonoBehaviour
{
    private GameObject focusDice;

    private Transform focusDicePosition;

    private float diceMoveSpeed;

    private void Start()
    {
        focusDice = GameObject.FindGameObjectWithTag("FocusDice");

        focusDicePosition = focusDice.transform;
    }
    
    public void moveDiceIntoFocus()
    {
        transform.position = Vector2.Lerp(transform.position, focusDicePosition.position, diceMoveSpeed * Time.deltaTime);
    }
}
