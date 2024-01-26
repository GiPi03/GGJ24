using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position,transform.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
    }
}
