using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinzessBullet : Bullet
{
    public Sprite[] bullets;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.Length)];
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<GiSchwanz>().SubHealth(damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<PrinzessBullet>() == null)
        {
            Destroy(gameObject);
        }
       
    }
}
