using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public AIPath aiPath;
    public float speed = 10f;
    public AIDestinationSetter aiDestinationSetter;
    float intTimer = 0;
    public float attackSpeed = 1f;
    private float attackTimer = 0f;
    bool canAttack = true;
    Transform playerPos;
    // Start is called before the first frame update

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    private void Update() {
        Debug.Log(Vector2.Distance(transform.position, playerPos.position));
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackSpeed)
        {
            if (Vector2.Distance(transform.position, playerPos.position) < 1f)
            {
                Attack();
            }
        }
        
    }
    

    private void Attack()
    {
        playerPos.GetComponent<GiSchwanz>().SubHealth(10);
        attackTimer = 0;
    }
}

