using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    public float shots = 0;
    public float magazine = 10;

    bool isreloading;
   
    



    // Update is called once per frame

    //Wenn Linksklick dann nicht dauerschieﬂen


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isreloading)
        {
            
            Shoot();
            
        }

   

        if (Input.GetKeyDown(KeyCode.R))
        {
            isreloading = true;

            StartCoroutine(Reload());
        }
     

        if (shots == magazine)
        {
            isreloading = true;

            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, transform.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
        Destroy(bulletInstance, 5);
        shots++;

    }
    IEnumerator Reload()
    {
        shots = 0;
        yield return new WaitForSeconds(3);
        isreloading = false;

    }
   
}
