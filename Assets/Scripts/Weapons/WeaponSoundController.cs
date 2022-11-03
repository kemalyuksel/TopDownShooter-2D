using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundController : MonoBehaviour
{
    public AudioClip weaponSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            SoundManager.Instance.PlayWeaponEffect(weaponSound, 1f);
            DamagePopUp.Create(transform.position, 1);
        }
    }
}
