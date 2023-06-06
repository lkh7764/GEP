using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HurbMob : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;

    private bool isActive;
    private bool isTouched;

    private float interval;
    public GameObject bullet;

    void Start()
    {
        isActive = false;
        isTouched = false;

        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

        Set();

        interval = 3f;
    }

    void Update()
    {
        if (!isActive)
            return;

        if (isTouched == false)
            agent.destination = target.transform.position;

        interval -= Time.deltaTime;

        if (interval <= 0f)
            ShootBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            isTouched = true;
            other.GetComponent<Player>().Attacked(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouched = false;
        }
    }

    private void ShootBullet()
    {
        GameObject b = Instantiate(bullet);
        Vector3 b_pos = this.transform.position;
        b_pos.y += 1f;
        b.transform.position = b_pos;
        b.transform.rotation = this.transform.rotation;

        interval = 3f;
    }

    public void Set()
    {
        Debug.Log(this.transform.position);
        agent.enabled = true;
        isActive = true;
    }
}
