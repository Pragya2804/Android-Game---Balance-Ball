using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PAProximity.onProximityChange = Break;
    }

    void Break(PAProximity.Proximity arg)
    {
        x += 1;
        if (x == 5)
        {
            Destroy(this.gameObject);
        }
    }
}
