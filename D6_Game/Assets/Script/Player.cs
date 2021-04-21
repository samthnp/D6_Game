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

   private GameObject currentDice;

   private GameObject diceToDestroy;

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
            
            if (hit.collider.CompareTag("DiceObject") && diceFocusPos.focusDiceOccupy == false)
            {
               Debug.Log("Hit something : " + hit.collider.name);
               // moving the dice into focus

               hit.transform.position = Vector2.MoveTowards(hit.transform.position, focusDiceTransform.position,
                  diceFocusMoveSpeed * Time.fixedDeltaTime);

               Debug.Log("Move dice into focus");

               Invoke("FocusIsOccupy", 0.5f);
               
               hit.transform.tag = "FocusDice";
               
               PlayerReceiveScore();
               
               chainActivate = true;

               if (chainActivate == true)
               {
                  PlayerReceiveChainPoint();
               }

               currentColor = hit.transform.GetComponent<DiceObject>().diceColor; 
               currentNumberValue = hit.transform.GetComponent<DiceObject>().diceNumberValue;
               
               print(currentColor);
               print(currentNumberValue);

               //diceColumn.MoveUpperToLower();

               //diceColumn.MoveHiddenToUpper();
            }
            
            
            
            /////////////////// If there is already a dice in the focus section ////////////////////

            if (hit.collider.CompareTag("DiceObject") && diceFocusPos.focusDiceOccupy == true && 
                currentNumberValue + 1 == hit.transform.GetComponent<DiceObject>().diceNumberValue)
            {
               

               // move new dice into focus
               hit.transform.position = Vector2.MoveTowards(hit.transform.position, focusDiceTransform.position,
                  diceFocusMoveSpeed * Time.fixedDeltaTime);
               
               hit.transform.tag = "FocusDice";
               
               Invoke("FocusIsOccupy", 0.5f);
               
               PlayerReceiveScore();
               
               chainActivate = true;

               if (chainActivate == true)
               {
                  PlayerReceiveChainPoint();
               }

               currentColor = hit.transform.GetComponent<DiceObject>().diceColor; 
               currentNumberValue = hit.transform.GetComponent<DiceObject>().diceNumberValue;
               
               print(currentColor);
               print(currentNumberValue);

            }


            //////////////////////// removing the focus dice and decrease player's health /////////////////////////////
            
            if (hit.collider.CompareTag("FocusDice") && diceFocusPos.focusDiceOccupy == true)
            {
               DecreasePlayerHealth();
               
               // removing the focus dice
               hit.transform.position =
                  Vector2.Lerp(hit.transform.position, removeDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);
               Debug.Log("Removing dice");
               
               Invoke("FocusIsNotOccupy", 0.5f);
               
               chainActivate = false;
               ChainPointReset();
            }
         }

      }
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
      }
   }
   
}
