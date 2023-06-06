using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private bool isPoison = false;

    void Start()
    {
        if (this.CompareTag("E_Bullet"))
            isPoison = true;
        Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPoison)
        {
            if(other.CompareTag("Player"))
                Destroy(this.gameObject);
        }
        else
        {
            if(other.CompareTag("Mob"))
                Destroy(this.gameObject);
        }
    }
}
