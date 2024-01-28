using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessEnemy : RangeEnemy
{
    public Animator animator;
    public override void Update()
    {
        base.Update();
        if (GetComponent<EnemyHealth>().health < 20f)
        {
            animator.SetTrigger("IsPrinzess");
        }
    }
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("IsAttack");
    }

}
