using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceGrid : MonoBehaviour
{
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


    // // // // //

    public GameObject[] diceToSpawn;
    private int randomInt;

    private bool emptyIsTrigger;

    // Reference for each dice in the grid
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

    public float diceMoveSpeed = 1000f;

    private void Start()
    {
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

    private void ActivateUpperSpawner1()
    {
        randomInt = Random.Range(0, diceToSpawn.Length);
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

    //////////////// Dice Refill ////////////////

    private void MoveUpper1ToLower1()
    {
        upperDice1.transform.position =
            Vector2.Lerp(upperDice1.transform.position, lowerSpawner1.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice1.name = "lowerDice1";

        Invoke("ActivateUpperSpawner1", 0.25f);
    }

    private void MoveUpper2ToLower2()
    {
        upperDice2.transform.position =
            Vector2.Lerp(upperDice2.transform.position, lowerSpawner2.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice2.name = "lowerDice2";
        
        Invoke("ActivateUpperSpawner2", 0.25f);
    }

    private void MoveUpper3ToLower3()
    {
        upperDice3.transform.position =
            Vector2.Lerp(upperDice3.transform.position, lowerSpawner3.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice3.name = "lowerDice3";
        
        Invoke("ActivateUpperSpawner3", 0.25f);
    }

    private void MoveUpper4ToLower4()
    {
        upperDice4.transform.position =
            Vector2.Lerp(upperDice4.transform.position, lowerSpawner4.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice4.name = "lowerDice4";
        
        Invoke("ActivateUpperSpawner4", 0.25f);
    }

    private void MoveUpper5ToLower5()
    {
        upperDice5.transform.position =
            Vector2.Lerp(upperDice5.transform.position, lowerSpawner5.transform.position,
                diceMoveSpeed * Time.deltaTime);

        upperDice5.name = "lowerDice5";
        
        Invoke("ActivateUpperSpawner5", 0.25f);
    }

    ////// Condition Check //////


    public void diceConditionCheck1()
    {
        if (lowerDice1 != null)
        {
            if (lowerDice1.transform.position != lowerSpawner1.transform.position)
            {
                Invoke("MoveUpper1ToLower1", 0.35f); 
            } 
        }

        else
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

        else
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

        else
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

        else
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

        else
        {
            Invoke("MoveUpper5ToLower5", 0.35f); 
        }
    }


}
