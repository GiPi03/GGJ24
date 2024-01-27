using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Weapon : MonoBehaviour
{
    public ParticleSystem ps;

    public int damage = 10;
    public GameObject bullet;
    public Transform shootPoint;
    public float shots = 0;
    public float magazine = 10;
    public float Timer = 0;
    public float rShots;
    public float rMagazine;
    public float holdTime = 1;

    bool isreloading;
    bool drei;
    bool rclick;

    int count = 0;

    private float originalEmissionRate;



    private void Start()
    {


    }


    // Update is called once per frame

    //Wenn Linksklick dann nicht dauerschieﬂen


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isreloading)
        {

            Shoot();

        }
        if (Input.GetKey(KeyCode.Mouse1))
        {


            Timer += Time.deltaTime;
            if (count < 3)
            {
                ps.Emit(1);
                count = 0;
            }
            count++;
            if (Timer >= holdTime)
            {
                drei = true;
                Timer = 0;
            }

        }



        if (Input.GetKeyUp(KeyCode.Mouse1) && drei) //Rechtsklick 3fach Schuss
        {


            StartCoroutine(RClick(3));
            drei = false;

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
    IEnumerator Hold()
    {
        yield return new WaitForSeconds(0.5f);
        rclick = false;
    }
    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, transform.rotation);
        bulletInstance.GetComponent<Bullet>().damage = damage;
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
        Destroy(bulletInstance, 5);
        shots++;

    }

    void rShoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, transform.rotation);
        bulletInstance.GetComponent<Bullet>().damage = 20;
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(-transform.right * 1000);
        Destroy(bulletInstance, 5);

    }
    IEnumerator Reload()
    {
        shots = 0;
        yield return new WaitForSeconds(3);
        isreloading = false;

    }
    IEnumerator RClick(int n)
    {
        for (int i = 0; i < n; i++)
        {
            rShoot();
            yield return new WaitForSeconds(0.2f);
        }
    }

}
