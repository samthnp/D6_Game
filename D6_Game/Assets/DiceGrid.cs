using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGrid : MonoBehaviour
{
    // 1st column
    public GameObject upperSpawner1;
    private Transform upperSpawn1Transform;
    
    public GameObject lowerSpawner1;
    private Transform lowerSpawn1Transform;
    
    public GameObject hiddenSpawner1;
    private Transform hiddenSpawn1Transform;

    private bool lowerSpawn1_Empty = false;
    
    // 2rd column
    public GameObject upperSpawner2;
    private Transform upperSpawn2Transform;
    
    public GameObject lowerSpawner2;
    private Transform lowerSpawn2Transform;
    
    private bool lowerSpawn2_Empty = false;
    
    public GameObject hiddenSpawner2;
    private Transform hiddenSpawn2Transform;
    
    // 3rd column
    public GameObject upperSpawner3;
    private Transform upperSpawn3Transform;
    
    public GameObject lowerSpawner3;
    private Transform lowerSpawn3Transform;
    
    public GameObject hiddenSpawner3;
    private Transform hiddenSpawn3Transform;
    
    private bool lowerSpawn3_Empty = false;
    
    // 4th column
    public GameObject upperSpawner4;
    private Transform upperSpawn4Transform;
    
    public GameObject lowerSpawner4;
    private Transform lowerSpawn4Transform;
    
    public GameObject hiddenSpawner4;
    private Transform hiddenSpawn4Transform;
    
    private bool lowerSpawn4_Empty = false;
    
    // 5th column
    public GameObject upperSpawner5;
    private Transform upperSpawn5Transform;
    
    public GameObject lowerSpawner5;
    private Transform lowerSpawn5Transform;
    
    public GameObject hiddenSpawner5;
    private Transform hiddenSpawn5Transform;
    
    private bool lowerSpawn5_Empty = false;

    private void Start()
    {
        upperSpawn1Transform = upperSpawner1.transform;
        lowerSpawn1Transform = lowerSpawner1.transform;
        hiddenSpawn1Transform = hiddenSpawner1.transform;

        upperSpawn2Transform = upperSpawner2.transform;
        lowerSpawn2Transform = lowerSpawner2.transform;
        hiddenSpawn2Transform = hiddenSpawner2.transform;

        upperSpawn3Transform = upperSpawner3.transform;
        lowerSpawn3Transform = lowerSpawner3.transform;
        hiddenSpawn3Transform = hiddenSpawner3.transform;
        
        upperSpawn4Transform = upperSpawner4.transform;
        lowerSpawn4Transform = lowerSpawner4.transform;
        hiddenSpawn4Transform = hiddenSpawner4.transform;
        
        upperSpawn5Transform = upperSpawner5.transform;
        lowerSpawn5Transform = lowerSpawner5.transform;
        hiddenSpawn5Transform = hiddenSpawner5.transform;
        

    }
    
    private void Spawn
}
