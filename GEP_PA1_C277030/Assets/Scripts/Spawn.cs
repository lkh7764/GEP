using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    public GameObject prefab1;    
    public GameObject prefab2;    
    public GameObject prefab3;

    public GameObject item;
    private float[] pos_y;

    void Start()
    {
        prefab = new GameObject[5] { prefab1, prefab1, prefab2, prefab2, prefab3 };
        pos_y = new float[3] { 1f, 2.5f, 4.5f };
    }

    public void CreatEnemy()
    {
        int num = Random.Range(0, 5);
        GameObject enemy = prefab[num];
        if(num != 4)
            Instantiate(enemy, transform.position, transform.rotation);
        else
            Instantiate(enemy, new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z), transform.rotation);
    }

    public void CreatItem()
    {
        float pos = pos_y[Random.Range(0, 3)];
        Instantiate(item, new Vector3(transform.position.x, pos, transform.position.z), transform.rotation);
    }
}
