using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiSchwanz : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    public void SubHealth(int amount)
    {
        if(health - amount <= 0)
        {
            Destroy(gameObject);
            return;
        }
        health -= amount;
    }
    public void AddHealth(int amount)
    {
        if(health  + amount >= maxHealth)
        {
            health = maxHealth;
            return;
        }
        health += amount;

    }
    
}
