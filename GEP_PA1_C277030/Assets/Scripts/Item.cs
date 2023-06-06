using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private float rotate_y;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        rotate_y += 50 * Time.deltaTime;
        if (rotate_y >= 360f)
            rotate_y = 0f;

        this.transform.rotation
            = Quaternion.Euler(0.0f, rotate_y, 90.0f);

        float speed = GameObject.Find("GameManager").GetComponent<GameManager>().speed;
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
    }
}
