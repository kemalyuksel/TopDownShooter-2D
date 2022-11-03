using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public Slider expBar;
    private float expCounter;


    private void Start()
    {
        expCounter = 0.1f;
    }
    public void UpdateXpBar()
    {
        expBar.value += expCounter;

        if (expBar.value >= 1)
        {
            expBar.value = 0;
            LevelUp();
        }


    }

    public void LevelUp()
    {
        expCounter -= 0.01f;
        PlayerController.Instance.playerLevel += 1;
        PlayerController.Instance.levelText.text = "Level " + PlayerController.Instance.playerLevel.ToString();
        LevelUpUIController.Instance.GetActiveDescriptions();
        LevelUpUIController.Instance.ToggleLevelUpUI();
        Time.timeScale = 0;
    }
}
