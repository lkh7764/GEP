using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Undead : MonoBehaviour
{
    public GameObject questCanvas;
    public GameObject clearCanvas;
    public GameObject nameText;
    private GameManager gameManager;

    public GameObject quest1;
    public GameObject quest2;

    private bool questClear;

    void Start()
    {
        questCanvas.SetActive(false);
        clearCanvas.SetActive(false);        
        quest1.SetActive(false);
        quest2.SetActive(false);

        nameText.transform.GetChild(0).gameObject.SetActive(true);
        nameText.transform.GetChild(1).gameObject.SetActive(false);
        nameText.transform.GetChild(2).gameObject.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        questClear = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (questClear && other.CompareTag("Player"))
            {
                clearCanvas.SetActive(true);
                return;
            }

            if (gameManager.getQuest == false && other.CompareTag("Player"))
            {
                questCanvas.SetActive(true);
                return;
            }
        }
    }

    public void ClickApply()
    {
        Debug.Log("apply");
        gameManager.StartStage(1);
        nameText.transform.GetChild(0).gameObject.SetActive(false);
        nameText.transform.GetChild(1).gameObject.SetActive(true);
        nameText.transform.GetChild(2).gameObject.SetActive(false);
        quest1.SetActive(true);
        questCanvas.SetActive(false);
    }

    public void ClearQuest()
    {
        nameText.transform.GetChild(0).gameObject.SetActive(false);
        nameText.transform.GetChild(1).gameObject.SetActive(false);
        nameText.transform.GetChild(2).gameObject.SetActive(true);
        quest1.SetActive(false);
        quest2.SetActive(true);
        questClear = true;
    }

    public void ClickNext()
    {
        gameManager.NextStage();
        SceneManager.LoadScene("Main2");
    }
}
