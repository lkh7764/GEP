using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    private Undead undead;
    private Undead2 undead2;
    private GameManager gameManager;

    public GameObject dealerCanvas;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(gameManager.GetStageNum() == 1)
        {
            undead = GameObject.Find("Undead").GetComponent<Undead>();
            undead2 = null;
        }
        else
        {
            undead = null;
            undead2 = GameObject.Find("Undead").GetComponent<Undead2>();
        }

        dealerCanvas.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (gameManager.GetTotalNum() >= 10 && other.CompareTag("Player"))
            {
                dealerCanvas.SetActive(true);
                return;
            }
        }
    }

    public void ClickDeal()
    {
        gameManager.SetHurbNum();
        if (undead != null)
            undead.ClearQuest();
        else
            undead2.ClearQuest();
        gameManager.getQuest = false;
        dealerCanvas.SetActive(false);
    }

    public void ClickClose()
    {
        dealerCanvas.SetActive(false);
    }
}
