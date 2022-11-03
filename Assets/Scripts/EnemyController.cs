using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform targetTransform;
    public float speed;
    public int health = 2;
    public GameObject enemyDeathPrefab;
    public AudioClip dieSound;
    private int rewardCount;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rewardCount = Random.Range(0, 3);
        targetTransform = GameObject.Find("Player").transform;
    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
        new Vector2(targetTransform.position.x - 0.2f, targetTransform.position.y - 0.2f)
        , speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            EnemyHit();
        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            StartCoroutine(BarrierAttack());
        }
    }

    private void EnemyHit()
    {
        DamagePopUp.Create(transform.position, 1);
        health--;
        if (health == 0)
        {
            PlayerController.Instance.UpdatePlayerCoin(rewardCount);
            PlayerController.Instance.UpdateScore();
            SoundManager.Instance.PlaySound(dieSound, 1f);
            Destroy(gameObject);
            GameObject deathEnemy = Instantiate(enemyDeathPrefab, transform.position, Quaternion.identity);
            Destroy(deathEnemy, .75f);
        }
    }

    private IEnumerator BarrierAttack()
    {
        EnemyHit();
        yield return new WaitForSeconds(1);
    }
}
