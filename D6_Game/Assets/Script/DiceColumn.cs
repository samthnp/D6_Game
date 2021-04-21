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

    private Transform upperDiceTranform;
    private Transform lowerDiceTranform;
    private Transform hiddenDiceTranform;

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

    private void Start()
    {
        hiddenSpawnTransform = hiddenSpawner.transform;
        upperSpawnerTransform = upperSpawner.transform;
        lowerSpawnerTransform = lowerSpawner.transform;
        
        StartSpawnUpperRow();
        StartSpawnLowerRow();
        StartSpawnHiddenRow();
    }

    private void StartSpawnUpperRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                GameObject upperDice = Instantiate(blueDice1, upperSpawnerTransform.position, Quaternion.identity);
                upperDiceTranform = upperDice.transform;
                print(upperDiceTranform);
                break;
            
            case 2:
                Instantiate(blueDice2, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 3:
                Instantiate(blueDice3, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 4:
                Instantiate(blueDice4, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 5:
                Instantiate(blueDice5, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 6:
                Instantiate(blueDice6, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 7:
                Instantiate(greenDice1, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 8:
                Instantiate(greenDice2, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 9:
                Instantiate(greenDice3, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 10:
                Instantiate(greenDice4, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 11:
                Instantiate(greenDice5, upperSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 12:
                Instantiate(greenDice6, upperSpawnerTransform.position, Quaternion.identity);
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
                break;
            
            case 2:
                Instantiate(blueDice2, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 3:
                Instantiate(blueDice3, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 4:
                Instantiate(blueDice4, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 5:
                Instantiate(blueDice5, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 6:
                Instantiate(blueDice6, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 7:
                Instantiate(greenDice1, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 8:
                Instantiate(greenDice2, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 9:
                Instantiate(greenDice3, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 10:
                Instantiate(greenDice4, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 11:
                Instantiate(greenDice5, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 12:
                Instantiate(greenDice6, lowerSpawnerTransform.position, Quaternion.identity);
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
                break;
            
            case 2:
                Instantiate(blueDice2, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 3:
                Instantiate(blueDice3, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 4:
                Instantiate(blueDice4, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 5:
                Instantiate(blueDice5, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 6:
                Instantiate(blueDice6, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 7:
                Instantiate(greenDice1, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 8:
                Instantiate(greenDice2, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 9:
                Instantiate(greenDice3, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 10:
                Instantiate(greenDice4, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 11:
                Instantiate(greenDice5, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 12:
                Instantiate(greenDice6, hiddenSpawnTransform.position, Quaternion.identity);
                break;
        }
    }
}
