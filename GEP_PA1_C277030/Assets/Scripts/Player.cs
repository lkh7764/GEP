using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int jumpPower;
    private int jumpCount;
    private float pos_x;

    private int itemCount;
    private float feverTime;
    public bool isFever;

    public Material feverColor;
    public Material playerColor;

    private AudioSource audio;
    public AudioClip jumpSound;
    public AudioClip itemSound;

    void Start()
    {
        jumpCount = 0;
        pos_x = this.transform.position.x;

        itemCount = 0;
        feverTime = 0;
        isFever = false;

        this.audio = this.gameObject.GetComponent<AudioSource>();
        this.audio.loop = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }

        if(collision.gameObject.tag == "Block")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().isOver = true;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if(this.tag == "Player")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().isOver = true;
                Destroy(this.gameObject);
            }

            if(this.tag == "Fever")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().score++;
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().score++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Item")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().score += 5;
            Destroy(other.gameObject);
            itemCount++;
            this.audio.clip = this.itemSound;
            this.audio.Play();
            if (itemCount == 5)
            {
                feverTime = 0;
                this.tag = "Fever";
                this.GetComponent<MeshRenderer>().material = feverColor;
                isFever = true;
                itemCount = 0;
            }
        }
    }

    void Update()
    {
        PlayerInput();

        if (isFever)
        {
            Fever();
        }
    }

    private void PlayerInput()
    {
        // jump
        if (jumpCount < 2 && Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.GetComponent<Rigidbody>().velocity =
                new Vector3(0, jumpPower, 0);
            jumpCount++;

            this.audio.clip = this.jumpSound;
            this.audio.Play();
        }

        // left
        if (pos_x >= 0 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pos_x -= 2.5f;
            float pos_y = this.transform.position.y;
            this.transform.position = new Vector3(pos_x, pos_y, 0);
        }

        // right
        if (pos_x <= 0 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            pos_x += 2.5f;
            float pos_y = this.transform.position.y;
            this.transform.position = new Vector3(pos_x, pos_y, 0);
        }
    }

    private void Fever()
    {
        feverTime += Time.deltaTime;
        if (feverTime >= 10f)
        {
            this.tag = "Player";
            this.GetComponent<MeshRenderer>().material = playerColor;
            isFever = false;
        }
    }
}
