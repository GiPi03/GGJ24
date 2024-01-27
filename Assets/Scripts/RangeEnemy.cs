using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileTimer;
    public float projectileTimerMax;

    public float projectileDamage;
    public float range = 5f;
    public override void Attack()
    {
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = (playerPos.position - transform.position).normalized * projectileSpeed;
    }
    public override void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackSpeed)
        {
            if (Vector2.Distance(transform.position, playerPos.position) < range)
            {
                aiPath.canMove = false;
                Attack();
            }
            else
            {
                aiPath.canMove = true;
            }
        }
    }



}
