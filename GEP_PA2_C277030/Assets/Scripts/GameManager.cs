using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int hurb_p;
    private int hurb_m;
    private float time;
    private float interval = 10f;

    static public int suspicion = 0;
    static public int disturbance = 0;
    static public int stageNum = 1;

    public bool getQuest;

    public Text hurbText;
    public Text timerText;
    public Text susText;
    public Text disText;

    void Start()
    {
        hurb_p = 0;
        hurb_m = 0;
        time = 180f;

        getQuest = false;
    }

    void Update()
    {
        interval -= Time.deltaTime;

        if (getQuest == true)
            time -= Time.deltaTime;

        if (time <= 0f || suspicion >= 100)
            SceneManager.LoadScene("GameOver");

        if (suspicion >= 10 && interval <= 0)
        {
            suspicion--;
            interval = 10f;
        }

        PrintText();
        Cheat();
    }

    public void AddHurb()
    {
        hurb_p++;
        Debug.Log("Add hurb");
    }

    public int GetHurbNum()
    {
        return hurb_p;
    }

    public int GetTotalNum()
    {
        return hurb_m + hurb_p;
    }

    public void SetHurbNum()
    {
        hurb_p = 0;
        hurb_m = 0;
    }

    public void ManufactureHurb()
    {
        interval = 10f;
        hurb_p--;
        hurb_m++;
        disturbance += 5;

        int random = Random.Range(0, 4);
        if (random == 0)
            suspicion += 20;
    }

    public void StartStage(int num)
    {
        hurb_p = 0;
        hurb_m = 0;
        time = 180f;

        if(num == 1)
        {
            suspicion = 0;
            disturbance = 0;
            stageNum = 1;
        }

        getQuest = true;
    }

    public void NextStage()
    {
        stageNum++;
    }

    public int GetDis()
    {
        return disturbance;
    }

    public int GetStageNum()
    {
        return stageNum;
    }

    private void PrintText()
    {
        hurbText.text = "HERB: " + (hurb_p + hurb_m).ToString();
        timerText.text = "TIMER: " + ((int)time).ToString();
        susText.text = "SUSPICION: " + suspicion.ToString();
        disText.text = "DISTURBANCE: " + disturbance.ToString();
    }

    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.O))
            hurb_p++;
        if (Input.GetKeyDown(KeyCode.I))
            suspicion += 20;
        if (Input.GetKeyDown(KeyCode.U))
            disturbance += 10;
        if (Input.GetKeyDown(KeyCode.T))
            time -= 50;
    }
}
