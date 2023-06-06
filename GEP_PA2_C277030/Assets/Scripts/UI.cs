using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Main");
        GameManager.suspicion = 0;
        GameManager.disturbance = 0;
    }

    public void ClickQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
