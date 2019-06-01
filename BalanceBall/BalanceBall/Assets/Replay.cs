using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    // Start is called before the first frame update
    public string Level;

    public void ReplayGame()
    {
        SceneManager.LoadScene(Level);
    }
}
