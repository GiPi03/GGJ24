using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Enemy
{
    public Transform shootPoint;
    public Transform axis;
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileTimer;
    public float projectileTimerMax;

    public float projectileDamage;
    public float range = 5f;
    public override void Attack()
    {
        GameObject bullet = Instantiate(projectile, shootPoint.position, axis.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = (playerPos.position - transform.position).normalized * projectileSpeed;
    }
    public override void Update()
    {

        Vector2 dir = playerPos.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg-180;
        axis.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackSpeed)
        {
            if (Vector2.Distance(transform.position, playerPos.position) < range)
            {
                aiPath.canMove = false;
                Attack();
                attackTimer = 0f;
            }
            else
            {
                aiPath.canMove = true;
            }
        }
    }



}
