using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    //Initialsierung der Globalen Variablen
    //Geschwindigkeit
    public float speed = 10f;

    void Update()
    {
        //Get Input.
        //Input.GetAxis("Horizontal") gibt einen Wert zwischen -1, 0 oder 1 zurück, je nachdem ob die Taste gedrückt ist.
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Speichern des Inputs in einem Vector3 und Multiplizieren mit der Geschwindigkeit und der Zeit zwischen einem Frame.
        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        //Anwenden der Bewegung auf das Objekt.
        transform.Translate(movement);
    }
}
