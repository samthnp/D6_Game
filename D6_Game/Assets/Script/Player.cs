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
            
            
            //////////////////////// move the dice from the grid into focus ////////////////////////
            
            if (hit.collider.CompareTag("DiceObject") && diceFocusPos.focusDiceOccupy == false)
            {
               Debug.Log("Hit something : " + hit.collider.name);
               // moving the dice into focus

               hit.transform.position = 
                  Vector2.Lerp(hit.transform.position, focusDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);
               Debug.Log("Move dice into focus");

               Invoke("FocusIsOccupy", 0.5f);
               
               hit.transform.tag = "FocusDice";
            }
            
            
            
            
            //////////////////////// removing the focus dice /////////////////////////////
            
            if (hit.collider.CompareTag("FocusDice") && diceFocusPos.focusDiceOccupy == true)
            {
               DecreasePlayerHealth();
               
               // removing the dice
               hit.transform.position =
                  Vector2.Lerp(hit.transform.position, removeDiceTransform.position, diceFocusMoveSpeed * Time.deltaTime);
               Debug.Log("Removing dice");
               
               Invoke("FocusIsNotOccupy", 0.5f);
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
