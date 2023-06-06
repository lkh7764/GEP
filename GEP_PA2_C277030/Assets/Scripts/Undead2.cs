using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Undead2 : MonoBehaviour
{
    public GameObject questCanvas;
    public GameObject clearCanvas;
    public GameObject nameText;
    private GameManager gameManager;

    public GameObject quest1;
    public GameObject quest2;

    private int numOfMam;

    private bool list1Clear;
    private bool list2Clear;

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

        numOfMam = 0;

        list1Clear = false; 
        list2Clear = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (list1Clear && list2Clear && other.CompareTag("Player"))
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
        gameManager.StartStage(2);
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
        list1Clear = true;
    }

    public void ClickEnding()
    {
        if (gameManager.GetDis() == 100)
            SceneManager.LoadScene("HappyEnd");
        else
            SceneManager.LoadScene("GameClear");
    }

    public void AddNum()
    {
        numOfMam++;
        if (numOfMam >= 8)
            list2Clear = true;
    }

    private void Cheats()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameManager.NextStage();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            list1Clear = true;
            list2Clear = true;
        }
    }

    private void Update()
    {
        Cheats();
    }
}
