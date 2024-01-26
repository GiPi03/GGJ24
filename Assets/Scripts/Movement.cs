using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float acceleration = 20f;
    public float maxSpeed = 15f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        Debug.Log(movement);
        transform.Translate(movement);
    }
}
