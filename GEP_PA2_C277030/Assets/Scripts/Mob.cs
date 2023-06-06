using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    private GameObject mob;
    private GameManager gameManager;
    private Undead2 undead;

    void Start()
    {
        mob = this.transform.parent.gameObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (gameManager.GetStageNum() == 2)
            undead = GameObject.Find("Undead").GetComponent<Undead2>();
        else
            undead = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collsion");
        if (other.CompareTag("Player"))
        {
            if (!this.CompareTag("Mob"))
            {
                other.GetComponent<Player>().Jump(0.5f);
                if (undead != null)
                    undead.AddNum();
                Destroy(mob.gameObject);
            }
            else
                other.GetComponent<Player>().Attacked(5);
        }
    }
}
