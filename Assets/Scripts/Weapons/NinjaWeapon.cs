using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaWeapon : MonoBehaviour
{
    private GameObject target;
    public float speed;
    public int level;
    public GameObject[] Shurikens;


    private void Start()
    {
        level = 1;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, speed * Time.deltaTime);
    }


    public void UpdateWeapon()
    {
        switch (level)
        {
            case 1:
                Shurikens[0].SetActive(true);
                break;
            case 2:
                Shurikens[1].SetActive(true);
                speed += 100;
                break;
            case 3:
                speed += 100;
                break;
            case 4:
                Shurikens[2].SetActive(true);
                break;
            case 5:
                speed += 100;
                break;
            case 6:
                Shurikens[3].SetActive(true);
                break;
            case 7:
                speed += 100;
                break;
            default:
                break;
        }
        level++;
    }


}
