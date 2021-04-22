using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceColumn : MonoBehaviour
{
    public GameObject hiddenSpawner;
    private Transform hiddenSpawnTransform;

    public GameObject upperSpawner;
    private Transform upperSpawnerTransform;

    public GameObject lowerSpawner;
    private Transform lowerSpawnerTransform;

    private int whichDiceToSpawn;

    private GameObject upperDice;
    private GameObject lowerDice;
    private GameObject hiddenDice;

    private Transform upperDiceTransform;
    private Transform lowerDiceTransform;
    private Transform hiddenDiceTransform;

    public GameObject blueDice1;
    public GameObject blueDice2;
    public GameObject blueDice3;
    public GameObject blueDice4;
    public GameObject blueDice5;
    public GameObject blueDice6;
    
    public GameObject greenDice1;
    public GameObject greenDice2;
    public GameObject greenDice3;
    public GameObject greenDice4;
    public GameObject greenDice5;
    public GameObject greenDice6;

    private bool isUpperDice = false;
    private bool isLowerDice = false;
    private bool isHiddenDice = false;

    public float diceMovementSpeed;

    private void Start()
    {
        hiddenSpawnTransform = hiddenSpawner.transform;
        upperSpawnerTransform = upperSpawner.transform;
        lowerSpawnerTransform = lowerSpawner.transform;
        
        StartSpawnUpperRow();
        StartSpawnLowerRow();
        StartSpawnHiddenRow();
    }

    private void Update()
    {
        testFunction();
    }

    private void StartSpawnUpperRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                upperDice = Instantiate(blueDice1, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 2:
                upperDice = Instantiate(blueDice2, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 3:
                upperDice = Instantiate(blueDice3, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 4:
                upperDice = Instantiate(blueDice4, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 5:
                upperDice = Instantiate(blueDice5, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 6:
                upperDice = Instantiate(blueDice6, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 7:
                upperDice = Instantiate(greenDice1, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 8:
                upperDice = Instantiate(greenDice2, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 9:
                upperDice = Instantiate(greenDice3, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 10:
                upperDice = Instantiate(greenDice4, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 11:
                upperDice = Instantiate(greenDice5, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
            
            case 12:
                upperDice = Instantiate(greenDice6, upperSpawnerTransform.position, Quaternion.identity);
                isUpperDice = true;
                break;
        }
    }
    
    private void StartSpawnLowerRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                Instantiate(blueDice1, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 2:
                Instantiate(blueDice2, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 3:
                Instantiate(blueDice3, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 4:
                Instantiate(blueDice4, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 5:
                Instantiate(blueDice5, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 6:
                Instantiate(blueDice6, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 7:
                Instantiate(greenDice1, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 8:
                Instantiate(greenDice2, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 9:
                Instantiate(greenDice3, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 10:
                Instantiate(greenDice4, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 11:
                Instantiate(greenDice5, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
            
            case 12:
                Instantiate(greenDice6, lowerSpawnerTransform.position, Quaternion.identity);
                isLowerDice = true;
                break;
        }
    }
    
    private void StartSpawnHiddenRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                Instantiate(blueDice1, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 2:
                Instantiate(blueDice2, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 3:
                Instantiate(blueDice3, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 4:
                Instantiate(blueDice4, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 5:
                Instantiate(blueDice5, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 6:
                Instantiate(blueDice6, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 7:
                Instantiate(greenDice1, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 8:
                Instantiate(greenDice2, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 9:
                Instantiate(greenDice3, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 10:
                Instantiate(greenDice4, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 11:
                Instantiate(greenDice5, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
            
            case 12:
                Instantiate(greenDice6, hiddenSpawnTransform.position, Quaternion.identity);
                isHiddenDice = true;
                break;
        }
    }

    public void testFunction()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            upperDice.transform.position = 
                Vector2.Lerp(upperDice.transform.position, lowerSpawnerTransform.position,
                diceMovementSpeed * Time.deltaTime);
        }
    }

    public void MoveUpperToLower()
    {
        upperDice.transform.position = 
            Vector2.Lerp(upperDice.transform.position, lowerSpawner.transform.position, 100f * Time.deltaTime);
    }
    
    public void MoveHiddenToUpper()
    {
        Invoke("DoTheMovement", 0.25f);
    }

    public void DoTheMovement()
    {
        hiddenDice.transform.position = 
            Vector2.Lerp(hiddenDice.transform.position, upperSpawner.transform.position, 100f * Time.deltaTime);
    }
    
}
