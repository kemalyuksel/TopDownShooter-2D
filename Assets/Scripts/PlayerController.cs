using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private ExpManager expManager;

    private void Awake()
    {
        Instance = this;
    }

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator anim;
    public AudioClip hitClip;

    [Header("GamePlay")]
    public float speed;
    private Vector2 movement;

    [Header("PlayerStats")]
    public int playerHealth;
    public int playerCoin;
    public int score;
    public int playerLevel;

    [Header("UIElements")]
    public TMP_Text coinText;
    public TMP_Text healthText;
    public TMP_Text scoreText;

    public TMP_Text levelText;


    void Start()
    {
        expManager = GameObject.FindObjectOfType<ExpManager>();
        playerLevel = 1;
        levelText.text = "Level " + playerLevel.ToString();
        playerHealth = 3;
        healthText.text = playerHealth.ToString();
        playerCoin = 0;
        score = 0;
    }


    void Update()
    {

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.touches[0];
            movement.x = touch.deltaPosition.x;
            movement.y = touch.deltaPosition.y;
        }


        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

        Running();

    }

    private void Running()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }


    public void UpdatePlayerCoin(int reward)
    {
        playerCoin += reward;
        coinText.text = playerCoin.ToString();
    }

    public void UpdatePlayerHealth(int damage)
    {
        playerHealth -= damage;
        healthText.text = playerHealth.ToString();
    }

    public void UpdateScore()
    {
        score += 1;
        expManager.UpdateXpBar();
        scoreText.text = score.ToString();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SoundManager.Instance.PlaySound(hitClip, 1);
            UpdatePlayerHealth(1);
        }
    }


}
