using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    private int bulletCount;
    public int level;

    void Start()
    {
        level = 1;
        bulletCount = 1;
        cam = Camera.main;
    }


    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x, Input.mousePosition.y, 0
        ));

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        Vector3 targetDirection = mousePos - transform.position;

        float rotatZ = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotatZ);
    }

    private void Shoot()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        for (int i = 0; i < bulletCount; i++)
        {
            pos.y -= 0.1f;
            pos.x -= 0.1f;
            Instantiate(bulletPrefab, pos, Quaternion.identity);
        }
        SoundManager.Instance.PlayWeaponEffect(shootSound, 1f);
    }

    public void UpdateGun()
    {
        level++;
        bulletCount++;
    }
}
