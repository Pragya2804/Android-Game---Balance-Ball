using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tortoise : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, -Input.acceleration.z);
    }
}
