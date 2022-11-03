using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    SpaceGun,
    Barrier,
    Shuriken
}

public class SelectItemController : MonoBehaviour
{
    public Weapon weapon;

    public void UpdateItem()
    {
        switch (weapon)
        {
            case Weapon.SpaceGun:
                LevelUpUIController.Instance.weapons[2].gameObject.GetComponent<PlayerGun>().UpdateGun();
                break;
            case Weapon.Barrier:
                LevelUpUIController.Instance.weapons[1].gameObject.GetComponent<BarrierWeapon>().UpdateRadius();
                break;
            case Weapon.Shuriken:
                LevelUpUIController.Instance.weapons[0].gameObject.GetComponent<NinjaWeapon>().UpdateWeapon();
                break;
            default:
                break;
        }
        Time.timeScale = 1;
        LevelUpUIController.Instance.ToggleLevelUpUI();
    }




}
