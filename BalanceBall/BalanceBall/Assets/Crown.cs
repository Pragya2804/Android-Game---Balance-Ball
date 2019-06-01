using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crown : MonoBehaviour

{
    public UIManager ui;
    public string end;
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
            for (int i = 0; i < 12; i++)
            {
                ui.IncrementScore();
            }
            SceneManager.LoadScene(end);
            Destroy(gameObject);
        }
    }
}