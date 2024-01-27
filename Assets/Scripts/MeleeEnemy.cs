using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    
    public override void Attack()
    {
        playerPos.GetComponent<GiSchwanz>().SubHealth(10);
    }
    public override void Update()
    {
        attackTimer += Time.deltaTime;
        if(attackTimer >= attackSpeed)
        {
            if (Vector2.Distance(transform.position, playerPos.position) < 1f)
            {
                Attack();
            }
        }
    }
}
