using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   public Vector3 mouseLocation;
   public float diceFocusMoveSpeed;
   
   public GameObject focusDice;
   public Transform focusDiceTransform;

   public GameObject removeDice;
   public Transform removeDiceTransform;

   public DiceFocusPos diceFocusPos;

   public float playerHealth = 6;
   public HealthUI healthUI;

   public bool chainActivate = false;

   public ProgressBar progressBar;

   public DiceColumn diceColumn;

   private string currentColor;
   private int currentNumberValue;
   
   

  

   private void Start()
   {
      focusDice = GameObject.FindGameObjectWithTag("FocusTransform");
      focusDiceTransform = focusDice.transform;

      removeDice = GameObject.FindGameObjectWithTag("RemoveDice");
      removeDiceTransform = removeDice.transform;
   }

   private void Update()
   {
      OnMouseClick();
      ReloadGameScene();
   }

   private void OnMouseClick()
   {
      // run the condition when a mouse click happens
      if (Input.GetMouseButtonUp(0))
      {
         Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 mouseLocation2D = new Vector2(mouseLocation.x, mouseLocation.y);
         RaycastHit2D hit = Physics2D.Raycast(mouseLocation2D, Vector2.zero, 10f);
         

         // Check object of raycast from mouse
         if (hit.collider != null)
         {
            
            
            //////////////////////// move the dice from the grid into focus for the first time////////////////////////
            
            if (hit.collider.CompareTag("DiceObject") && 
                diceFocusPos.focusDiceOccupy == false && 
                hit.transform.GetComponent<DiceObject>().diceIsFocused == false)
            {
               Debug.Log("Hit something : " + hit.collider.name);
               // moving the dice into focus

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
               
               print(currentColor);
               print(currentNumberValue);

               //diceColumn.MoveUpperToLower();

               //diceColumn.MoveHiddenToUpper();
            }
            
            
            
            /////////////////// If there is already a dice in the focus section ////////////////////

            if (
               
               (hit.collider.CompareTag("DiceObject") && 
                diceFocusPos.focusDiceOccupy == true && 
                currentNumberValue + 1 == hit.transform.GetComponent<DiceObject>().diceNumberValue)
               
               ||
               
               (hit.collider.CompareTag("DiceObject") && 
                 diceFocusPos.focusDiceOccupy == true && 
                 currentColor == hit.transform.GetComponent<DiceObject>().diceColor)
               
               )
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
               
               print(currentColor);
               print(currentNumberValue);
               
               // set the bool value of clicked dice to true
               hit.transform.GetComponent<DiceObject>().CallDiceIsNowFocused();
            }


            //////////////////////// removing the focus dice and decrease player's health /////////////////////////////
            
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
               
               // set chain state to false and reset the chain score
               chainActivate = false;
               ChainPointReset();
               
               MoveDiceToDiscard();
            }
         }

      }
   }

   private void MoveDiceToDiscard()
   {
      GameObject[] diceToDiscard; 
      diceToDiscard = GameObject.FindGameObjectsWithTag("FocusDice");
      foreach (GameObject dice in diceToDiscard)
      {
         dice.transform.position = Vector2.Lerp
            (dice.transform.position, removeDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);
         print("Dice are discarded");
      }
   }

   private void MoveUpperDiceToLowerDice()
   {
      
   }

   private void FocusIsOccupy()
   {
      diceFocusPos.focusDiceOccupy = true;
   }

   private void FocusIsNotOccupy()
   {
      diceFocusPos.focusDiceOccupy = false;
   }

   private void PlayerReceiveScore()
   {
      ScoreCounter.scoreValue = ScoreCounter.scoreValue + 1;
      
      // also fill in the progress on the progression bar
      progressBar.IncreaseProgress(1);
   }

   private void PlayerReceiveChainPoint()
   {
      ChainCounter.chainValue = ChainCounter.chainValue + 1;
   }
   
   private void ChainPointReset()
   {
      ChainCounter.chainValue = 0;
   }

   public void DecreasePlayerHealth()
   {
      playerHealth = playerHealth - 1;
      healthUI.HealthUICheck();
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
   
}
