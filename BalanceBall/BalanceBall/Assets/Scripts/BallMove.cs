using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, (float)(-2.6), (float)(2.6));
        pos.y = Mathf.Clamp(pos.y, (float)(-4.5), (float)4.5);
        transform.Translate((Input.acceleration.x)/5, (Input.acceleration.y)/5, 0);
        pos.x = Mathf.Clamp(pos.x, (float)(-2.6), (float)(2.6));
        pos.y = Mathf.Clamp(pos.y, (float)(-4.5), (float)4.5);
    }
}
