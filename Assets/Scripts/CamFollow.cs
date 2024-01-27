using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, -10);
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
