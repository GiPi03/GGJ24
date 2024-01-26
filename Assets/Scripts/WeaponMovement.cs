using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public Transform weapon;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get mouse position
        Vector2 mouseDir = (Vector3)mousePos - transform.position; // Get weapon position
        float angle = Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg; // Get angle
        weapon.rotation = Quaternion.Euler(0,0,angle-180); // Set rotation
    }
}
