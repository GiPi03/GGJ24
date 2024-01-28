using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessEnemy : RangeEnemy
{
    public Animator animator;
    public void Update()
    {
        if (GetComponent<EnemyHealth>().health < 20f)
        {
            animator.SetTrigger("IsPrinzess");
        }
    }

}
