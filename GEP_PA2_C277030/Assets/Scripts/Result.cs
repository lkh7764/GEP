using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    private int highDis;
    public Text disText;

    private int highSus;
    public Text susText;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighDis"))
            highDis = PlayerPrefs.GetInt("HighDis");
        else
            highDis = 0;

        if (PlayerPrefs.HasKey("HighSus"))
            highSus = PlayerPrefs.GetInt("HighSus");
        else
            highSus = 0;
    }

    void Update()
    {
        int dis = GameManager.disturbance;
        int sus = GameManager.suspicion;

        disText.text = "CLEAR DISTURBANCE: " + dis.ToString() + "\n\nBEST DISTURBANCE: 0" + highDis.ToString();
        susText.text = "CLEAR SUSPICION: " + sus.ToString() + "\n\nBEST SUSPICION: 0" + highSus.ToString();

        if (highDis < dis)
            PlayerPrefs.SetInt("HighDis", dis); 
        if (highSus < sus)
            PlayerPrefs.SetInt("HighSus", sus);
    }
}
