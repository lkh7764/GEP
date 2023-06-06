using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutoCanvas;

    public GameObject tutoPages;

    static public int page;


    void Start()
    {
        tutoCanvas.SetActive(false);
        page = 0;
    }

    public void ClickTuto()
    {
        tutoCanvas.SetActive(true);
        Debug.Log("tuto");
        page = 0;
    }

    public void ClickNextPage()
    {
        if (page < 4)
            AddPage();
    }

    public void ClickBackPage()
    {
        if (page > 0)
            ReducePage();
    }

    public void ClickTitle()
    {
        tutoCanvas.SetActive(false);
        Debug.Log("title");
    }

    private void AddPage()
    {
        page++;
        Debug.Log(page);
        for (int i = 0; i < 5; i++)
        {
            if (i == page)
                tutoPages.transform.GetChild(i).gameObject.SetActive(true);
            else
                tutoPages.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void ReducePage()
    {
        page--;
        Debug.Log(page);
        for (int i = 0; i < 5; i++)
        {
            if (i == page)
                tutoPages.transform.GetChild(i).gameObject.SetActive(true);
            else
                tutoPages.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
