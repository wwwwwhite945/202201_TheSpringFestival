using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    [Header("Gate")]
    //public Text gateHpText;
    public Image geteHpImg;
    public Image gateImg;
    public Sprite gateSpr;
    int gateHp;             //gate血量
    int monsterDamage;      //怪物攻擊傷害

    [Space(10)]
    [Header("傷害提示文字")]
    public Text damageHint;

    [Space(10)]
    [Header("GameOver")]
    public GameObject gameOver;
    public Text killCounterText;
    public Text highKillCounterText;

    int stepHighCount;   //記錄歷史最高分數

    GameManager getGameManager;

    AudioSource audioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //遭撞擊音效
        audioSource.Play();
        if (collision.transform.tag == "monster")
        {
            monsterDamage = 10;
            damageHint.text = "家園受到攻擊!!請認真保護家園!!";
        }
        else if (collision.transform.tag == "monsterSky")
        {
            monsterDamage = 5;
            damageHint.text = "家園受到攻擊!!趕緊發射子彈攻擊!!";
        }
        gateHp -= monsterDamage;
        geteHpImg.fillAmount = gateHp * 0.01f;  //根據血量控制圖片填滿度
        //gateHpText.text = gateHp.ToString();
        Invoke("CleanDamageHint", 2f);
    }

    public void CleanDamageHint()   //清除提示文字
    {
        damageHint.text = "";
    }

    // Use this for initialization
    void Start()
    {
        getGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();

        //設定gate血量
        gateHp = 100;
        //gateHpText.text = gateHp.ToString();

        //取得歷史最高分數
        stepHighCount = PlayerPrefs.GetInt("highScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gateHp <= 0)
        {
            //判斷是否超過歷史最高分數
            if (stepHighCount < getGameManager.killCounter)
            {
                getGameManager.highKillCount = getGameManager.killCounter;
            }
            GameOver();
        }
        //當血量低於50，更換圖片
        if (gateHp <= 50)
        {
            gateImg.sprite = gateSpr;
        }
    }

    public void GameOver()
    {
        //暫停遊戲
        Time.timeScale = 0;

        gameOver.SetActive(true);
        killCounterText.text = "本次分數為：" + getGameManager.killCounter;
        highKillCounterText.text = "歷史最高分：" + stepHighCount;

        //儲存最高分數
        PlayerPrefs.SetInt("highScore", getGameManager.highKillCount);
    }
}
