using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Vector3 mouseLocation;

   public GameObject focusDice;
   public Transform focusDiceTransform;

   public GameObject removeDice;
   public Transform RemoveDiceTransform;

   public DiceFocusPos diceFocusPos;

   public float diceFocusMoveSpeed;

   private void Start()
   {
      focusDice = GameObject.FindGameObjectWithTag("FocusTransform");
      focusDiceTransform = focusDice.transform;

      removeDice = GameObject.FindGameObjectWithTag("RemoveDice");
      RemoveDiceTransform = removeDice.transform;
   }

   private void Update()
   {
      OnMouseClick();
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
            // move the dice from the grid into focus
            if (hit.collider.CompareTag("DiceObject") && diceFocusPos.focusDiceOccupy == false)
            {
               Debug.Log("Hit something : " + hit.collider.name);
               // moving the dice into focus

               hit.transform.position = 
                  Vector2.Lerp(hit.transform.position, focusDiceTransform.position, diceFocusMoveSpeed);
               Debug.Log("Move dice into focus");

               Invoke("FocusIsOccupy", 0.5f);
               
               hit.transform.tag = "FocusDice";
            }
            
            // removing the focus dice
            if (hit.collider.CompareTag("FocusDice") && diceFocusPos.focusDiceOccupy == true)
            {
               // removing the dice
               hit.transform.position =
                  Vector2.Lerp(hit.transform.position, RemoveDiceTransform.position, diceFocusMoveSpeed);
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
   
}
