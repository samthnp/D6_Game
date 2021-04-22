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
        print("Move upper dice to lower");
        upperDice.transform.position = 
            Vector2.Lerp(upperDice.transform.position, lowerSpawnerTransform.position,
                diceMovementSpeed * Time.deltaTime);

        upperDice.GetComponent<BoxCollider2D>().enabled = true;


        Invoke("MoveHiddenToUpper", 0.15f);
    }

    public void MoveHiddenToUpper()
    {
        hiddenDice.transform.position = 
            Vector2.Lerp(hiddenDice.transform.position, upperSpawnerTransform.position,
                diceMovementSpeed * Time.deltaTime);
    }


    private void StartSpawnUpperRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                upperDice = Instantiate(blueDice1, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 2:
                upperDice = Instantiate(blueDice2, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 3:
                upperDice = Instantiate(blueDice3, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 4:
                upperDice = Instantiate(blueDice4, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 5:
                upperDice = Instantiate(blueDice5, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 6:
                upperDice = Instantiate(blueDice6, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 7:
                upperDice = Instantiate(greenDice1, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 8:
                upperDice = Instantiate(greenDice2, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 9:
                upperDice = Instantiate(greenDice3, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 10:
                upperDice = Instantiate(greenDice4, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 11:
                upperDice = Instantiate(greenDice5, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
            
            case 12:
                upperDice = Instantiate(greenDice6, upperSpawnerTransform.position, Quaternion.identity);
                upperDice.GetComponent<BoxCollider2D>().enabled = false;
                
                break;
        }
    }
    
    private void StartSpawnLowerRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                lowerDice = Instantiate(blueDice1, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 2:
                lowerDice = Instantiate(blueDice2, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 3:
                lowerDice = Instantiate(blueDice3, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 4:
                lowerDice = Instantiate(blueDice4, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 5:
                lowerDice = Instantiate(blueDice5, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 6:
                lowerDice = Instantiate(blueDice6, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 7:
                lowerDice = Instantiate(greenDice1, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 8:
                lowerDice = Instantiate(greenDice2, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 9:
                lowerDice = Instantiate(greenDice3, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 10:
                lowerDice = Instantiate(greenDice4, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 11:
                lowerDice = Instantiate(greenDice5, lowerSpawnerTransform.position, Quaternion.identity);
                break;
            
            case 12:
                lowerDice = Instantiate(greenDice6, lowerSpawnerTransform.position, Quaternion.identity);
                break;
        }
    }
    
    private void StartSpawnHiddenRow()
    {
        whichDiceToSpawn = Random.Range(1, 12);

        switch (whichDiceToSpawn)
        {
            case 1:
                hiddenDice = Instantiate(blueDice1, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 2:
                hiddenDice = Instantiate(blueDice2, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 3:
                hiddenDice = Instantiate(blueDice3, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 4:
                hiddenDice = Instantiate(blueDice4, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 5:
                hiddenDice = Instantiate(blueDice5, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 6:
                hiddenDice = Instantiate(blueDice6, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 7:
                hiddenDice = Instantiate(greenDice1, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 8:
                hiddenDice = Instantiate(greenDice2, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 9:
                hiddenDice = Instantiate(greenDice3, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 10:
                hiddenDice = Instantiate(greenDice4, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 11:
                hiddenDice = Instantiate(greenDice5, hiddenSpawnTransform.position, Quaternion.identity);
                break;
            
            case 12:
                hiddenDice = Instantiate(greenDice6, hiddenSpawnTransform.position, Quaternion.identity);
                break;
        }
    }
}
