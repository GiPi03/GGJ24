using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    //Initialsierung der Globalen Variablen
    //Geschwindigkeit
    public Animator animator;
    public float speed = 10f;
    float currentInputX = 0;
    float currentInputY = 0;
    void Update()
    {
        //Get Input.
        //Input.GetAxis("Horizontal") gibt einen Wert zwischen -1, 0 oder 1 zurück, je nachdem ob die Taste gedrückt ist.
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0)
        {
            if(horizontal != currentInputX)
            {
                currentInputX = horizontal;
            }
            
        }
        if(vertical != 0)
        {
            if(vertical != currentInputY)
            {
                currentInputY = vertical;
            }
        }

        if(currentInputX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        //Speichern des Inputs in einem Vector3 und Multiplizieren mit der Geschwindigkeit und der Zeit zwischen einem Frame.
        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        //Anwenden der Bewegung auf das Objekt.
        transform.Translate(movement);
        animator.SetFloat("moveX", horizontal);
        animator.SetFloat("moveY", vertical);

    }
   
}
