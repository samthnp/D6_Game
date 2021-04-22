using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   // variable for the speed when focusing on a dice
   public float diceFocusMoveSpeed;
   
   // variable for the reference to the focusDice position
   public GameObject focusDice;
   public Transform focusDiceTransform;
   public DiceFocusPos diceFocusPos;

   // variable for the reference to the removedDice position
   public GameObject removeDice;
   public Transform removeDiceTransform;
   
   // variable for the health system also a reference to the health UI
   public float playerHealth = 6;
   public HealthUI healthUI;

   // boolean variable for the activation of chain point system
   public bool chainActivate = false;

   // for referencing the progression bar
   public ProgressBar progressBar;

   // for referencing the grid system
   public DiceGrid diceGrid;

   // variable for the dice condition check, contain the value for color and number of the dice
   private string currentColor;
   private int currentNumberValue;

   // variable that will return true if the current dice is 6 and the selected dice is 1
   private bool diceExceptionTriggered = false;

   // for referencing the sound manager class
   public SoundManager soundManager;

   private void Start()
   {
      // set transform for the focus dice position
      focusDice = GameObject.FindGameObjectWithTag("FocusTransform");
      focusDiceTransform = focusDice.transform;

      // set transform for the removed dice position
      removeDice = GameObject.FindGameObjectWithTag("RemoveDice");
      removeDiceTransform = removeDice.transform;
   }

   private void Update()
   {
      // call whenever click a mouse
      OnMouseClick();
      
      // for debugging, pressing r will reload the scene
      ReloadGameScene();

      // for debugging, pressing G will increase the score
      if (Input.GetKeyUp(KeyCode.G))
      {
         PlayerReceiveScore();
      }
   }

   // activate when player click on the left mouse button
   private void OnMouseClick()
   {
      // run the condition when a mouse click happens
      if (Input.GetMouseButtonUp(0))
      {
         // get the accurate mouse position on the screen
         Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         // set the new mouse position
         Vector2 mouseLocation2D = new Vector2(mouseLocation.x, mouseLocation.y);
         // cast a raycast hit to where the mouse is clicked
         RaycastHit2D hit = Physics2D.Raycast(mouseLocation2D, Vector2.zero, 10f);
         

         // Check object of raycast from mouse only if it's not null
         if (hit.collider != null)
         {
            // if it hits a dice object and there is nothing in focus, and it follows the dice condition, this will make the exception of 6->1 true
            if (hit.collider.CompareTag("DiceObject") &&
                diceFocusPos.focusDiceOccupy == true &&
                hit.transform.GetComponent<DiceObject>().diceNumberValue == 1 &&
                currentNumberValue == 6)
            {
               diceExceptionTriggered = true;
            }


            // if it hits a dice object and there is nothing in focus, and it follows the dice condition
            // also for moving dice in the first time (focus is empty)
            if (hit.collider.CompareTag("DiceObject") &&
                diceFocusPos.focusDiceOccupy == false &&
                hit.transform.GetComponent<DiceObject>().diceIsFocused == false)
            {
               // check which object the raycast hit
               Debug.Log("Hit something : " + hit.collider.name);

               // move the dice into focus
               hit.transform.position = Vector2.MoveTowards(hit.transform.position, focusDiceTransform.position,
                  diceFocusMoveSpeed * Time.fixedDeltaTime);

               Debug.Log("Move dice into focus");

               // set the focus to occupy
               Invoke("FocusIsOccupy", 0.5f);

               // set the tag of the clicked dice to focusDice
               hit.transform.tag = "FocusDice";

               // set the bool value of clicked dice to true
               hit.transform.GetComponent<DiceObject>().CallDiceIsNowFocused();

               // player receive one score
               PlayerReceiveScore();

               // player receive one chain
               chainActivate = true;

               // if player run to this loop again they will get another chain point
               if (chainActivate == true)
               {
                  PlayerReceiveChainPoint();
               }

               // set the color and number value of the clicked dice into current value
               currentColor = hit.transform.GetComponent<DiceObject>().diceColor;
               currentNumberValue = hit.transform.GetComponent<DiceObject>().diceNumberValue;
               
               // this function will determine which audio to play depending on the chain point
               WhichAudioToPlay();
               
               // debugging the current values
               print(currentColor);
               print(currentNumberValue);
               
               // access the dice object and set that it is no longer in the grid
               hit.transform.GetComponent<DiceObject>().diceIsOutOfGrid = true;

               
               // depending on which dice object is hit by accessing the variable on it, run a check on the grid system
               // for the dice refill accordingly
               
               // if it's from column 1
               if (hit.transform.GetComponent<DiceObject>().isColumn1 == true)
               {
                  // run a check on column 1, which will refill the dice from upper to lower row
                  diceGrid.diceConditionCheck1();
                  // for debugging which check was activated
                  print("Check condition 1");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn2 == true)
               {
                  diceGrid.diceConditionCheck2();
                  print("Check condition 2");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn3 == true)
               {
                  diceGrid.diceConditionCheck3();
                  print("Check condition 3");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn4 == true)
               {
                  diceGrid.diceConditionCheck4();
                  print("Check condition 4");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn5 == true)
               {
                  diceGrid.diceConditionCheck5();
                  print("Check condition 5");
               }

            }


            // If there is already a dice in the focus section but the condition returns true, run this check instead
            
            // if the condition returns true but there is already a dice in focus, remove the focused dice before moving new ones in
            if ((hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 currentNumberValue + 1 == hit.transform.GetComponent<DiceObject>().diceNumberValue)

                ||

                (hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 currentColor == hit.transform.GetComponent<DiceObject>().diceColor)

                ||

                (hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 diceExceptionTriggered == true))
            {
               MoveDiceToDiscard();

               // move new dice into focus
               hit.transform.position = Vector2.MoveTowards
               (hit.transform.position, focusDiceTransform.position,
                  diceFocusMoveSpeed * Time.fixedDeltaTime);

               // set the dice with focus tag
               hit.transform.tag = "FocusDice";

               // set the occupy state to true
               Invoke("FocusIsOccupy", 0.5f);

               // player receive one score
               PlayerReceiveScore();

               // chain is activated
               chainActivate = true;

               // player receive one chain point
               if (chainActivate == true)
               {
                  PlayerReceiveChainPoint();
               }

               // continue to set current value of color and number from the clicked dice
               currentColor = hit.transform.GetComponent<DiceObject>().diceColor;
               currentNumberValue = hit.transform.GetComponent<DiceObject>().diceNumberValue;
               
               WhichAudioToPlay();

               print(currentColor);
               print(currentNumberValue);

               diceExceptionTriggered = false;

               // set the bool value of clicked dice to true
               hit.transform.GetComponent<DiceObject>().CallDiceIsNowFocused();

               hit.transform.GetComponent<DiceObject>().diceIsOutOfGrid = true;

               if (hit.transform.GetComponent<DiceObject>().isColumn1 == true)
               {
                  diceGrid.diceConditionCheck1();
                  print("Check condition 1");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn2 == true)
               {
                  diceGrid.diceConditionCheck2();
                  print("Check condition 2");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn3 == true)
               {
                  diceGrid.diceConditionCheck3();
                  print("Check condition 3");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn4 == true)
               {
                  diceGrid.diceConditionCheck4();
                  print("Check condition 4");
               }

               if (hit.transform.GetComponent<DiceObject>().isColumn5 == true)
               {
                  diceGrid.diceConditionCheck5();
                  print("Check condition 5");
               }

            }

            // If there are already a dice in focus, but the condition return false
            // play a sound signifying that they can't be moved
            if ((hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 currentNumberValue + 1 != hit.transform.GetComponent<DiceObject>().diceNumberValue)

                ||

                (hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 currentColor != hit.transform.GetComponent<DiceObject>().diceColor)

                ||

                (hit.collider.CompareTag("DiceObject") &&
                 diceFocusPos.focusDiceOccupy == true &&
                 diceExceptionTriggered != true))
            {
                  soundManager.PlayWrongConditionSound();
            }
            

            // removing the focus dice and decrease player's health
            // bying clicking on the already focused dice, it will be discarded but player lose 1 health point
            if (hit.collider.CompareTag("FocusDice") && 
                diceFocusPos.focusDiceOccupy == true &&
                hit.transform.GetComponent<DiceObject>().diceIsFocused == true)
            {
               // decrease player's health by one
               DecreasePlayerHealth();
               
               // removing the focus dice
               hit.transform.position =
                  Vector2.Lerp(hit.transform.position, removeDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);
               Debug.Log("Removing dice");
               
               // set the occupy state to false
               Invoke("FocusIsNotOccupy", 0.5f);
               
               // play the sound when discarding
               soundManager.PlayDiscardSound();
               
               // set chain state to false and reset the chain score
               chainActivate = false;
               ChainPointReset();
               
               // then move dice into discard
               MoveDiceToDiscard();
            }
         }

      }
   }

   // moving the focused dice into discard
   private void MoveDiceToDiscard()
   {
      // get an array of the dice with focus tag
      GameObject[] diceToDiscard; 
      diceToDiscard = GameObject.FindGameObjectsWithTag("FocusDice");
      foreach (GameObject dice in diceToDiscard)
      {
         // lerping them downward
         dice.transform.position = Vector2.Lerp
            (dice.transform.position, removeDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);

         // then after a few seconds, destroy it
         Invoke("DestroyDiscardDice", 2f);
      }
   }

   // destroying the dice
   private void DestroyDiscardDice()
   {
      // find object that were moved down and destroy them
      GameObject[] diceToDiscard; 
      diceToDiscard = GameObject.FindGameObjectsWithTag("FocusDice");
      foreach (GameObject dice in diceToDiscard)
      {
         if (dice.transform.position != focusDiceTransform.position)
         {
            Destroy(dice);
         }
      }
   }

   // set the focus section to true
   private void FocusIsOccupy()
   {
      diceFocusPos.focusDiceOccupy = true;
   }

   // set the focus section to false
   private void FocusIsNotOccupy()
   {
      diceFocusPos.focusDiceOccupy = false;
   }

   // give player one score, fill the bar and play sound
   private void PlayerReceiveScore()
   {
      ScoreCounter.scoreValue = ScoreCounter.scoreValue + 1;
      
      // also fill in the progress on the progression bar
      progressBar.IncreaseProgress(1);
      soundManager.PlayConditionMetSound1();
      
      // also run a state check if the game is won
      GameStateCheck();
   }

   // give player 1 chain point
   private void PlayerReceiveChainPoint()
   {
      ChainCounter.chainValue = ChainCounter.chainValue + 1;
   }
   
   // reset the chain point to zero
   private void ChainPointReset()
   {
      ChainCounter.chainValue = 0;
   }

   // decrease the player's health by 1
   public void DecreasePlayerHealth()
   {
      playerHealth = playerHealth - 1;
      
      // update the health bar
      healthUI.HealthUICheck();
      
      // also run a game over check
      GameOverCheck();
   }

   public void GameOverCheck()
   {
      if (playerHealth <= 0)
      {
         print("Game over");
         SceneManager.LoadScene("GameOverScene");
      }
   }

   // check if game is won after 50 points
   public void GameStateCheck()
   {
      if (ScoreCounter.scoreValue >= 50)
      {
         SceneManager.LoadScene("VictoryScene");
      }
   }

   // reload scene for debugging
   private void ReloadGameScene()
   {
      if (Input.GetKeyUp(KeyCode.R))
      {
         SceneManager.LoadScene("GameScene");
         ScoreCounter.scoreValue = 0;
         ChainCounter.chainValue = 0;
         playerHealth = 6;
         
         progressBar.ResetBar();
      }
   }

   // change sounds to be played when receving score, base on the chain points 
   void WhichAudioToPlay()
   {
      if (ChainCounter.chainValue <= 1)
      {
         soundManager.PlayConditionMetSound1();
      }
      
      if (ChainCounter.chainValue == 2)
      {
         soundManager.PlayConditionMetSound2();
      }
      
      if (ChainCounter.chainValue == 3)
      {
         soundManager.PlayConditionMetSound3();
      }
      
      if (ChainCounter.chainValue == 4)
      {
         soundManager.PlayConditionMetSound4();
      }
      
      if (ChainCounter.chainValue == 5)
      {
         soundManager.PlayConditionMetSound5();
      }
      
      if (ChainCounter.chainValue == 6)
      {
         soundManager.PlayConditionMetSound6();
      }
   }
   
}
