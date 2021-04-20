using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Vector3 mouseLocation;

   public GameObject focusDice;
   public Transform focusDiceTransform;

   public float diceFocusMoveSpeed;

   private void Start()
   {
      focusDice = GameObject.FindGameObjectWithTag("FocusDice");
      focusDiceTransform = focusDice.transform;
   }

   private void Update()
   {
      OnMouseClick();
   }

   private void OnMouseClick()
   {
      if (Input.GetMouseButtonUp(0))
      {
         Vector3 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector2 mouseLocation2D = new Vector2(mouseLocation.x, mouseLocation.y);
         RaycastHit2D hit = Physics2D.Raycast(mouseLocation2D, Vector2.zero, 10f);
         
         Debug.DrawLine(mouseLocation2D,Vector2.zero);

         if (hit.collider != null)
         {
            if (hit.collider.CompareTag("DiceObject"))
            {
               Debug.Log("Hit something : " + hit.collider.name);
               hit.transform.position = Vector2.Lerp(hit.transform.position, focusDiceTransform.position,
                  diceFocusMoveSpeed);

            }
         }

      }
   }
   
}
