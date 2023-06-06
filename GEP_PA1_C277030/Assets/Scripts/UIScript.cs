using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIScript : MonoBehaviour
{
    public Texture2D[] tuto;
    public Texture2D tuto1;
    public Texture2D tuto2;
    public Texture2D tuto3;
    public bool isTuto;
    public int tuto_num;

    public GameObject tutoCanvas;

    private void Start()
    {
        tuto = new Texture2D[3] { tuto1, tuto2, tuto3 };
        isTuto = false;
        tuto_num = 0;

        tutoCanvas.GetComponent<UIScript>().isTuto = true;
    }

    private void Update()
    {
        if (isTuto)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (tuto_num < 2)
                    tutoCanvas.GetComponent<UIScript>().tuto_num++;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (tuto_num > 0)
                    tutoCanvas.GetComponent<UIScript>().tuto_num--;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("click backToTitle");
                SceneManager.LoadScene("Title");
            }
        }
    }

    private void OnGUI()
    {
        if (isTuto)
        {
            GUI.DrawTexture(new Rect(0, 0, 800, 600), tuto[tuto_num]);               
        }
    }

    public void ClickStart()
    {
        Debug.Log("click start");
        SceneManager.LoadScene("Main");
    }

    public void ClickTuto()
    {
        SceneManager.LoadScene("Tuto");
    }

    public void ClickNextP()
    {
        if(tuto_num < 2)
            tutoCanvas.GetComponent<UIScript>().tuto_num++;
    }

    public void ClickBackP()
    {
        if(tuto_num > 0)
            tutoCanvas.GetComponent<UIScript>().tuto_num--;
    }

    public void ClickBackT()
    {
        Debug.Log("click backToTitle");
        SceneManager.LoadScene("Title");
    }

    public void ClickRestart()
    {
        Debug.Log("click restart");
        SceneManager.LoadScene("Main");
    }

    public void ClickExit()
    {
        Debug.Log("click exit");
        Application.Quit();
    }
}
