using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
   protected override void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
           collision.gameObject.GetComponent<GiSchwanz>().SubHealth(damage);
           Destroy(gameObject);
       }
   }
}
