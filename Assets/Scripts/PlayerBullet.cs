using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public Sprite[] bullets;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.Length)];
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().SubHealth(damage);
            Destroy(gameObject);
        }
    }
}
