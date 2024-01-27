using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFairyHover : MonoBehaviour
{
    float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(0, 0.5f * Mathf.Sin(2 *timer), 0);
    }
}
