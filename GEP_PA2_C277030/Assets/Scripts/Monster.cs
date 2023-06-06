using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;

    private bool isFollowed;
    private float interval = 10f;

    void Start()
    {
        isFollowed = false;

        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(isFollowed == true)
            agent.destination = target.transform.position;
        else
        {
            interval -= Time.deltaTime;
            if(interval<= 0f)
            {
                agent.destination = 
                    new Vector3(Random.Range(-40f, 40f), this.transform.position.y, Random.Range(-40f, 40f));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFollowed = true;
            agent.speed = 5f;
        }
    }
}
