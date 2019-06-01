using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour
{
    public string end;
    public Text timerT;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        timerT.text ="Timer"+": "+ t.ToString("f2");

        if(t.ToString("f2") == "25.00")
        {
            SceneManager.LoadScene(end);
        }

    }
}
