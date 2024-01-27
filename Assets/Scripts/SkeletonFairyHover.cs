using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFairyHover : MonoBehaviour
{
    float timer = 0f;
    public float speed = 2f;
    public float amplitude = 0.5f;
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(0, amplitude * Mathf.Sin(speed*timer), 0);
    }
}
