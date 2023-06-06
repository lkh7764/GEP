using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isOver;
    public bool isClear;
    private bool isStop;

    private Text timeText;
    private float time;

    private Text scoreText;
    public int score;

    public float spawnRange;
    public float itemRange;
    public float speed;

    public GameObject GameOverUI;
    public GameObject GameClearUI;

    void Start()
    {
        isOver = false;
        isClear = false;
        isStop = false;

        timeText = GameObject.Find("Time").GetComponent<Text>();
        time = 180f;

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;

        spawnRange = 3f;
        itemRange = 5f; 
        speed = 25f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SceneManager.LoadScene("Main");
        }

        CountTime();
        CountScore();

        if (isOver)
        {
            GameStop();
            GameOverUI.SetActive(true);
        }
        if (isClear)
        {
            GameStop();
            GameClearUI.SetActive(true);
            GameObject.Find("Nav_score").GetComponent<Text>().text
                = "YOUR SCORE: " + score.ToString();
        }

        Stage(time);
        CheatKey();
    }

    private void CountTime()
    {
        timeText.text = "Time  : " + ((int)time).ToString();

        if (!isOver && time > 0)
            time -= Time.deltaTime;
        else if (!isOver)
            isClear = true;
    }

    private void CountScore()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    private void Stage(float time)
    {
        if (spawnRange > 2f && time <= 120f)
        {
            spawnRange = 1.8f;
            speed = 40f;
        }
        else if (spawnRange > 1.5f && time <= 60f)
        {
            GameObject.Find("Spawner").GetComponent<SpawnerController>().isLastStage = true;
            spawnRange = 1.2f;
            speed = 60f;
        }
    }

    private void GameStop()
    {
        // Destroy(GameObject.Find("Player").GetComponent<Player>());
        if (!isStop)
        {
            Destroy(GameObject.Find("Spawner").gameObject);
            isStop = true;
        }
    }

    private void CheatKey()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            time -= 10;
        }
    }
}
