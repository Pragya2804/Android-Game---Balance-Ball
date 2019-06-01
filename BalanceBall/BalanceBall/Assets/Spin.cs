using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sppinn();
        PAProximity.onProximityChange = spin;
    }
    void spin(PAProximity.Proximity arg)
    {
        x += 1;
        if(x == 5)
        {
            Destroy(GameObject.FindWithTag("wall"));
        }
    }
    void sppinn()
    {
        transform.Rotate(0, 0, -9);
    }
}
