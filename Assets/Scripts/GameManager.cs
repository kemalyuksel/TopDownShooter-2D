using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text gameText;
    public GameObject restartButton;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
    }


    private void Update()
    {
        if (PlayerController.Instance.playerHealth == 0)
        {
            Time.timeScale = 0;
            gameText.enabled = true;
            restartButton.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
