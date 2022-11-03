using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector2 target;
    public float speed;
    public AudioClip bulletHit;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        Destroy(gameObject, 2f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            SoundManager.Instance.PlayWeaponEffect(bulletHit, 1f);
            DamagePopUp.Create(transform.position, 1);
            Destroy(gameObject);
        }
    }
 
}
