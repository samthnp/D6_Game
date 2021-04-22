using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceGrid : MonoBehaviour
{
    // setting up references for all the position the dice will spawn in the grid system
    // the grid system is a 5 column and 2 row grid
    
    // 1st column
    public GameObject upperSpawner1;
    public GameObject lowerSpawner1;


    // 2rd column
    public GameObject upperSpawner2;
    public GameObject lowerSpawner2;


    // 3rd column
    public GameObject upperSpawner3;
    public GameObject lowerSpawner3;


    // 4th column
    public GameObject upperSpawner4;
    public GameObject lowerSpawner4;


    // 5th column
    public GameObject upperSpawner5;
    public GameObject lowerSpawner5;


    // a variable of gameObject array for the dice to be spawn
    // this array contain all the possible dice to be spawn, numbers and color variation included
    public GameObject[] diceToSpawn;
    // a random int number to be selected in randomization
    private int randomInt;

    // a boolean trigger when any slot on the grid is empty
    private bool emptyIsTrigger;

    // Reference for each dice in the grid as gameObject
    private GameObject upperDice1;
    private GameObject upperDice2;
    private GameObject upperDice3;
    private GameObject upperDice4;
    private GameObject upperDice5;

    private GameObject lowerDice1;
    private GameObject lowerDice2;
    private GameObject lowerDice3;
    private GameObject lowerDice4;
    private GameObject lowerDice5;

    private GameObject hiddenDice1;
    private GameObject hiddenDice2;
    private GameObject hiddenDice3;
    private GameObject hiddenDice4;
    private GameObject hiddenDice5;

    // the move speed of when the dice is rotating around in the grid
    public float diceMoveSpeed = 1000f;

    private void Start()
    {
        // spawn all the dice in their locaiton
        ActivateUpperSpawner1();
        ActivateUpperSpawner2();
        ActivateUpperSpawner3();
        ActivateUpperSpawner4();
        ActivateUpperSpawner5();

        ActivateLowerSpawner1();
        ActivateLowerSpawner2();
        ActivateLowerSpawner3();
        ActivateLowerSpawner4();
        ActivateLowerSpawner5();
    }

    // each activation function for specific points in the grid
    
    // this starts from upper-1 to upper-5 & from lower-1 to lower-5
    private void ActivateUpperSpawner1()
    {
        // random an object to spawn from the array of all possible dice
        randomInt = Random.Range(0, diceToSpawn.Length);
        // then instantiate the randomized dice into their position
        upperDice1 = Instantiate(diceToSpawn[randomInt], upperSpawner1.transform.position, Quaternion.identity);

    }

    private void ActivateUpperSpawner2()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        upperDice2 = Instantiate(diceToSpawn[randomInt], upperSpawner2.transform.position, Quaternion.identity);
    }

    private void ActivateUpperSpawner3()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        upperDice3 = Instantiate(diceToSpawn[randomInt], upperSpawner3.transform.position, Quaternion.identity);
    }

    private void ActivateUpperSpawner4()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        upperDice4 = Instantiate(diceToSpawn[randomInt], upperSpawner4.transform.position, Quaternion.identity);
    }

    private void ActivateUpperSpawner5()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        upperDice5 = Instantiate(diceToSpawn[randomInt], upperSpawner5.transform.position, Quaternion.identity);
    }

    private void ActivateLowerSpawner1()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        lowerDice1 = Instantiate(diceToSpawn[randomInt], lowerSpawner1.transform.position, Quaternion.identity);
    }

    private void ActivateLowerSpawner2()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        lowerDice2 = Instantiate(diceToSpawn[randomInt], lowerSpawner2.transform.position, Quaternion.identity);
    }

    private void ActivateLowerSpawner3()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        lowerDice3 = Instantiate(diceToSpawn[randomInt], lowerSpawner3.transform.position, Quaternion.identity);
    }

    private void ActivateLowerSpawner4()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        lowerDice4 = Instantiate(diceToSpawn[randomInt], lowerSpawner4.transform.position, Quaternion.identity);
    }

    private void ActivateLowerSpawner5()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
        lowerDice5 = Instantiate(diceToSpawn[randomInt], lowerSpawner5.transform.position, Quaternion.identity);
    }

    //////////////// Dice Refill System ////////////////

    // when this function gets called, it will move the upper row to the lower row
    // then the moved dice is removed so that when the newly moved dice is clicked again, it will run the loop
    
    // then an invoke is called to spawn a new dice in the upper column to refill the grid
    private void MoveUpper1ToLower1()
    {
        // move the upper dice downward to replace the recently selected dice
        upperDice1.transform.position =
            Vector2.Lerp(upperDice1.transform.position, lowerSpawner1.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice1.name = "lowerDice1";

        // invoke some delay for the new dice to refill the upper row
        Invoke("ActivateUpperSpawner1", 0.5f);
        
        print("Move upper 1 to lower 1");
    }

    private void MoveUpper2ToLower2()
    {
        upperDice2.transform.position =
            Vector2.Lerp(upperDice2.transform.position, lowerSpawner2.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice2.name = "lowerDice2";
        
        Invoke("ActivateUpperSpawner2", 0.5f);
        
        print("Move upper 2 to lower 2");
    }

    private void MoveUpper3ToLower3()
    {
        upperDice3.transform.position =
            Vector2.Lerp(upperDice3.transform.position, lowerSpawner3.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice3.name = "lowerDice3";
        
        Invoke("ActivateUpperSpawner3", 0.5f);
        
        print("Move upper 3 to lower 3");
    }

    private void MoveUpper4ToLower4()
    {
        upperDice4.transform.position =
            Vector2.Lerp(upperDice4.transform.position, lowerSpawner4.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice4.name = "lowerDice4";
        
        Invoke("ActivateUpperSpawner4", 0.5f);
        
        print("Move upper 4 to lower 4");
    }

    private void MoveUpper5ToLower5()
    {
        upperDice5.transform.position =
            Vector2.Lerp(upperDice5.transform.position, lowerSpawner5.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice5.name = "lowerDice5";
        
        Invoke("ActivateUpperSpawner5", 0.5f);
        
        print("Move upper 5 to lower 5");
    }

    ////// Condition Check //////


    
    // these functions gets called according to which columns they belong to when the players clicked on the dice
    
    // each function will run a test if the lower dice of that column is missing or not
    // if it's missing, it will call the dice refill functions above and run the loop
    public void diceConditionCheck1()
    {
        if (lowerDice1 != null)
        {
            if (lowerDice1.transform.position != lowerSpawner1.transform.position)
            {
                Invoke("MoveUpper1ToLower1", 0.35f); 
            } 
        }

        else if (lowerDice1 == null)
        {
            Invoke("MoveUpper1ToLower1", 0.35f); 
        }
    }
    
    public void diceConditionCheck2()
    {
        if (lowerDice2 != null)
        {
            if (lowerDice2.transform.position != lowerSpawner2.transform.position)
            {
                Invoke("MoveUpper2ToLower2", 0.35f); 
            } 
        }

        else if (lowerDice2 == null)
        {
            Invoke("MoveUpper2ToLower2", 0.35f); 
        }
    }
    
    public void diceConditionCheck3()
    {
        if (lowerDice3 != null)
        {
            if (lowerDice3.transform.position != lowerSpawner3.transform.position)
            {
                Invoke("MoveUpper3ToLower3", 0.35f); 
            } 
        }

        else if (lowerDice3 == null)
        {
            Invoke("MoveUpper3ToLower3", 0.35f); 
        }
    }
    
    public void diceConditionCheck4()
    {
        if (lowerDice4 != null)
        {
            if (lowerDice4.transform.position != lowerSpawner4.transform.position)
            {
                Invoke("MoveUpper4ToLower4", 0.35f); 
            } 
        }

        else if (lowerDice4 == null)
        {
            Invoke("MoveUpper4ToLower4", 0.35f); 
        }
    }

    public void diceConditionCheck5()
    {
        if (lowerDice5 != null)
        {
            if (lowerDice5.transform.position != lowerSpawner5.transform.position)
            {
                Invoke("MoveUpper5ToLower5", 0.35f); 
            } 
        }

        else if (lowerDice5 == null)
        {
            Invoke("MoveUpper5ToLower5", 0.35f); 
        }
    }

}
