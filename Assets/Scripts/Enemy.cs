using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AIPath aiPath;
    public float speed = 10f;
    public int damage = 10;
    public AIDestinationSetter aiDestinationSetter;

    public float attackSpeed = 1f;
    protected float attackTimer = 0f;
    protected bool canAttack = true;
    protected Transform playerPos;
    // Start is called before the first frame update

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        aiPath.maxSpeed = speed;
        
    }
    // Update is called once per frame

    public virtual void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        aiDestinationSetter.target = playerPos;

    }

    public virtual void Attack()
    {

    }
}

