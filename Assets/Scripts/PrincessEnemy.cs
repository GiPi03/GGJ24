using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrincessEnemy : RangeEnemy
{
    public Animator animator;
    public override void Update()
    {
        base.Update();
        if (GetComponent<EnemyHealth>().health < 20f)
        {
            animator.SetBool("isHealed",true);
            GetComponent<EnemyHealth>().enabled = false;
            GetComponent<Enemy>().enabled = false;
            StartCoroutine(ShowEndScreen());
        }
        
    }
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("IsAttack");
    }
    IEnumerator ShowEndScreen()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Win1");
    }

}
