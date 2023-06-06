using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 360f;
    public float jumpPower = 10f;
    private float gravity = 20f;
    private Vector3 moveDir;

    private int hp;
    public Slider hpBar;

    private bool isActive;
    private float time = 3f;

    public GameObject bullet;

    public GameObject cam;
    public GameObject gameManager;

    public Text posText;

    private int rock;
    public Text rockText;

    CharacterController charController;
    Animator animator;

    private AudioSource audio;
    public AudioClip fail;
    public AudioClip get;
    public AudioClip act;
    public AudioClip swing;
    public AudioClip jump;

    void Start()
    {
        moveDir = Vector3.zero;

        hp = 100;

        isActive = false;

        rock = 0;

        charController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        audio = GetComponent<AudioSource>();
        this.audio.loop = false;
    }

    void Update()
    {
        Health();
        posText.text = "X: " + ((int)this.transform.position.x).ToString() + "\nZ: " + ((int)this.transform.position.z).ToString();
        rockText.text = "ROCK: " + rock.ToString();

        Cheat();

        if (isActive)
        {
            if(time > 0f)
            {
                time -= Time.deltaTime;
                return;
            }
            time = 2f;
            isActive = false;
        }
        PlayerMove();

        if (Input.GetKeyDown(KeyCode.R))
            ShootBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            Debug.Log("ddd");
            hp -= 5;
            Jump(1.2f);
            return;
        }

        if (other.CompareTag("E_Bullet"))
        {
            hp -= 5;
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (!gameManager.GetComponent<GameManager>().getQuest)
                return;

            if (other.CompareTag("HurbMob"))
            {
                hp -= 5;
                moveDir.y = jumpPower * 1.2f;
                animator.SetBool("Jump", true);
                audio.clip = fail;
                this.audio.Play();
                Debug.Log("mob");
                return;
            }

            if (other.CompareTag("Hurb"))
            {
                GameManager script = gameManager.GetComponent<GameManager>();
                if (script.GetHurbNum() < 10)
                {
                    script.AddHurb();
                    animator.SetTrigger("Action");
                    audio.clip = act;
                    this.audio.Play();
                    isActive = true;
                    Destroy(other.gameObject);
                    return;
                }
            }

            if (other.CompareTag("Rock"))
            {
                rock++;
                audio.clip = get;
                this.audio.Play();
                Destroy(other.gameObject);
                return;
            }

            if (isActive == false && other.CompareTag("Table"))
            {
                GameManager script = gameManager.GetComponent<GameManager>();
                if (script.GetHurbNum() > 0)
                {
                    script.ManufactureHurb();
                    animator.SetTrigger("Action");
                    audio.clip = act;
                    this.audio.Play();
                    isActive = true;
                    return;
                }
            }
        }
    }

    private void PlayerMove()
    {
        if (charController.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (moveDir.sqrMagnitude > 0.1f)
            {
                Vector3 forward = Vector3.Slerp(
                    transform.forward, moveDir,
                    rotateSpeed * Time.deltaTime / Vector3.Angle(transform.forward, moveDir));
                transform.LookAt(transform.position + forward);
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            moveDir *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(1f);
            }
        }
        else
            animator.SetBool("Jump", false);

        moveDir.y -= gravity * Time.deltaTime;

        charController.Move(moveDir * Time.deltaTime);
        cam.transform.position = new Vector3
            (this.transform.position.x, this.transform.position.y + 3, this.transform.position.z - 5);
    }

    private void Health()
    {
        hpBar.value = hp * 0.01f;

        if (hp <= 0)
            SceneManager.LoadScene("GameOver");
    }

    private void ShootBullet()
    {
        if(rock > 0)
        {
            GameObject b = Instantiate(bullet);
            Vector3 b_pos = this.transform.position;
            b_pos.y += 1f;
            b.transform.position = b_pos;
            b.transform.rotation = this.transform.rotation;

            audio.clip = swing;
            this.audio.Play();
            rock--;
        }
    } 

    public void Attacked(int damage)
    {
        hp -= damage;
    }

    public void Jump(float num)
    {
        moveDir.y = jumpPower * num;
        animator.SetBool("Jump", true);
        audio.clip = jump;
        this.audio.Play();
    }

    private void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.P))
            hp -= 10;
        if (Input.GetKeyDown(KeyCode.L))
            rock += 10;
    }
}
