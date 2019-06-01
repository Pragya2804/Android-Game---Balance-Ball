using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public UIManager ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ball")
        {
            for (int i = 0; i < 3; i++)
            {
                ui.IncrementScore();
            }
            
        }
        Destroy(gameObject);
    }

}
