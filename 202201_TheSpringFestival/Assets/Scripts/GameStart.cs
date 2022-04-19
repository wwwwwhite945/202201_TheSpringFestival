using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [Header("HighScore")]
    int highScore = 0;
    public Text highScoreText;

    [Space(10)]
    [Header("Setting")]
    public GameObject setting;

    [Space(10)]
    [Header("DoubleCheckExit")]
    public GameObject doubleCheckExit;

    [Space(10)]
    [Header("DoubleCheckReset")]
    public GameObject doubleCheckReset;
    public Button closeBtn;

    public AudioSource audioSource;
    static bool isAudioPlay = true;

    // Use this for initialization
    void Start()
    {
        if (isAudioPlay)    //避免生成第二個AudioSource
        {
            DontDestroyOnLoad(audioSource);
            isAudioPlay = false;
            audioSource.Play();
        }

        Screen.SetResolution(/*螢幕寬度*/1920,/*螢幕高度*/ 1080, /*是否全屏顯示*/true); //控制畫面大小及比例

        highScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "歷史最高分:" + highScore;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("GameStart");
    }

    #region 遊戲設定
    public void Setting()
    {
        setting.SetActive(true);
    }

    public void BackLobby()
    {
        setting.SetActive(false);
    }
    #endregion

    #region 結束遊戲
    public void DoubleCheckExit()
    {
        doubleCheckExit.SetActive(true);
    }

    public void CancelExit()
    {
        doubleCheckExit.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region 清除遊戲紀錄
    public void DoubleCheckReset()
    {
        doubleCheckReset.SetActive(true);
        closeBtn.enabled = false;
    }

    public void CancelReset()
    {
        doubleCheckReset.SetActive(false);
        closeBtn.enabled = true;
    }

    public void CleanRecord()
    {
        PlayerPrefs.SetInt("highScore", 0);
        SceneManager.LoadScene("GameLobby");
    }
    #endregion

    #region 版權連接網站
    public void OpenCopyRightURL(string url)
    {
        if (url == "sound effect")
        {
            Application.OpenURL("https://taira-komori.jpn.org/freesoundtw.html");
        }
        else if (url == "music")
        {
            Application.OpenURL("https://youtube.com");
        }
        else if (url == "font")
        {
            Application.OpenURL("https://github.com/ButTaiwan/gensen-font");
        }

    }

    #endregion

    // Update is called once per frame
    void Update()
    {

    }
}
