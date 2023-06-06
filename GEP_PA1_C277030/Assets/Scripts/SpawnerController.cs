using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public bool isLastStage;

    void Start()
    {
        isLastStage = false;

        StartCoroutine(EnemySpawn());
        StartCoroutine(ItemSpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            float spawnRange = GameObject.Find("GameManager").GetComponent<GameManager>().spawnRange;
            int num = Random.Range(0, 3);

            yield return new WaitForSeconds(spawnRange);
            if (!isLastStage)
            {
                GameObject spawner = this.transform.GetChild(num).gameObject;
                spawner.GetComponent<Spawn>().CreatEnemy();
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i != num)
                    {
                        GameObject spawner = this.transform.GetChild(i).gameObject;
                        spawner.GetComponent<Spawn>().CreatEnemy();
                    }
                }
            }
        }
    }

    IEnumerator ItemSpawn()
    {
        while (true)
        {
            float itemRange = GameObject.Find("GameManager").GetComponent<GameManager>().itemRange;
            GameObject spawner = this.transform.GetChild(Random.Range(0, 3)).gameObject;

            yield return new WaitForSeconds(itemRange);
            if(!GameObject.Find("Player").GetComponent<Player>().isFever)
                spawner.GetComponent<Spawn>().CreatItem();
        }
    }
}
