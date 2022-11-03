using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpUIController : MonoBehaviour
{
    public static LevelUpUIController Instance;

    public List<GameObject> weapons;
    public GameObject levelUpUI;
    public TMP_Text[] itemDescriptions;

    Dictionary<int, string> shurikenDescriptions = new Dictionary<int, string>();
    Dictionary<int, string> spaceGunDescriptions = new Dictionary<int, string>();
    Dictionary<int, string> barrierDescriptions = new Dictionary<int, string>();

    private int shurikenLevel, barrierLevel, gunLevel;

    private void Awake()
    {
        Instance = this;
        gunLevel = 1;
        barrierLevel = 1;
        shurikenLevel = 1;
    }

    private void Start()
    {
        SetItemDescriptions();
    }

    public void ToggleLevelUpUI()
    {
        levelUpUI.SetActive(!levelUpUI.activeInHierarchy);
    }

    public void GetActiveLevels()
    {
        gunLevel = weapons[2].gameObject.GetComponent<PlayerGun>().level;
        barrierLevel = weapons[1].gameObject.GetComponent<BarrierWeapon>().level;
        shurikenLevel = weapons[0].gameObject.GetComponent<NinjaWeapon>().level;
    }

    public void GetActiveDescriptions()
    {
        GetActiveLevels();
        itemDescriptions[0].text = shurikenDescriptions[shurikenLevel];
        itemDescriptions[1].text = barrierDescriptions[barrierLevel];
        itemDescriptions[2].text = spaceGunDescriptions[gunLevel];
    }

    public void SetItemDescriptions()
    {
        shurikenDescriptions.Add(1, "Get Shuriken");
        shurikenDescriptions.Add(2, "Update Shuriken Count +1 and Speed");
        shurikenDescriptions.Add(3, "Update Shuriken Speed");
        shurikenDescriptions.Add(4, "Update Shuriken Count +1");
        shurikenDescriptions.Add(5, "Update Shuriken Speed");
        shurikenDescriptions.Add(6, "Update Shuriken Count +1");
        shurikenDescriptions.Add(7, "Update Shuriken Count +1");

        spaceGunDescriptions.Add(1, "Update Bullet Count +1");
        spaceGunDescriptions.Add(2, "Update Bullet Count +1");
        spaceGunDescriptions.Add(3, "Update Bullet Count +1");
        spaceGunDescriptions.Add(4, "Update Bullet Count +1");
        spaceGunDescriptions.Add(5, "Update Bullet Count +1");


        barrierDescriptions.Add(1, "Get Barrier");
        barrierDescriptions.Add(2, "Update Barrier Radius ");
        barrierDescriptions.Add(3, "Update Barrier Radius ");
        barrierDescriptions.Add(4, "Update Barrier Radius ");
        barrierDescriptions.Add(5, "Update Barrier Radius ");
        barrierDescriptions.Add(6, "Update Barrier Radius ");
    }


}
