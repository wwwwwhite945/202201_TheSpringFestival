using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Space(10)]
    [Header("目前擊敗數")]
    public Text killCounterNowText;

    [Header("Pause")]
    public GameObject pause;
    public int killCounter;
    public Text killCounterText;
    public int highKillCount;
    public Text highKillCountText;
    int isPause;

    [Space(10)]
    [Header("DoubleCheck")]
    public GameObject doubleCheck;

    // Use this for initialization
    void Start()
    {
        isPause = 0;
    }

    //顯示提示是否要回首頁的畫面
    public void isChangeScene()
    {
        doubleCheck.SetActive(true);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("GameLobby");
    }

    public void CancelChangeScene()
    {
        doubleCheck.SetActive(false);
    }

    public void PauseGame()
    {
        killCounterText.text = "目前擊敗數：" + killCounter;
        highKillCountText.text = "歷史最高分：" + PlayerPrefs.GetInt("highScore", 0);
        pause.SetActive(true);
        isPause = 1;
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pause.SetActive(false);
        isPause = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && isPause == 0)
        {
            PauseGame();
        }
        else if (Input.GetButtonDown("Cancel") && isPause == 1)
        {
            ContinueGame();
        }
    }
}
