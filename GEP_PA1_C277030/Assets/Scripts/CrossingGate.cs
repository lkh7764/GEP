using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingGate : MonoBehaviour
{
    public int LorR;
    public bool isBlocked;
    public float time;
    public float blockRange;
    public float blockTime;

    private GameObject bar;
    public float rotate_z;

    void Start()
    {
        LorR = 0;   // 0: left, 1: right
        isBlocked = false;
        time = 0f;
        blockRange = 20f;
        blockTime = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= blockRange)
        {
            RotateBar(); }
            
    }

    private void RotateBar()
    {
        if (!isBlocked)
        {
            Debug.Log("adf");
            blockTime = 0f;
            LorR = Random.Range(0, 2);
            if (LorR == 0)
            {
                bar = this.transform.GetChild(0).gameObject;
                rotate_z = 0f;
                bar.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotate_z);
            }
            else
            {
                bar = this.transform.GetChild(1).gameObject;
                rotate_z = 180f;
                bar.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotate_z);
            }
            isBlocked = true;
        }

        blockTime += Time.deltaTime;

        if (blockTime >= 10f)
        {
            bar.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            time = 0;
            isBlocked = false;
        }
    }
}
