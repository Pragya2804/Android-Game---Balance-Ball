using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    Scene m_Scene;
    public static int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        m_Scene = SceneManager.GetActiveScene();

        //Check if the current Active Scene's name is your first Scene
        if (m_Scene.name == "SampleScene")
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
