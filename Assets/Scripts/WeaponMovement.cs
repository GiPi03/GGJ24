using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform weapon;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get mouse position
        Vector2 mouseDir = (Vector3)mousePos - transform.position; // Get weapon position
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg; // Get angle
        Debug.Log(angle);
        if(angle > 60f && angle < 150f) // If angle is between 60 and 120
        {
            weapon.GetComponent<SpriteRenderer>().sortingOrder = 4; // Set weapon sorting order to 4
        }
        else
        {
            weapon.GetComponent<SpriteRenderer>().sortingOrder = 6; // Set weapon sorting order to 6
        }
        weapon.rotation = Quaternion.Euler(0,0,angle-180); // Set rotation
    }
}
