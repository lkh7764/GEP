using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        float speed = GameObject.Find("GameManager").GetComponent<GameManager>().speed;
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
