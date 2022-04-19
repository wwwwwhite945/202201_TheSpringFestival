using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    //public Text monsterHpText;
    public Image monsterHpImg;
    int monsterHp;
    int damage;

    //怪物移動速度
    float moveSpeed = 100f;
    float moveSpeedSky = 150f;

    Animator anim;

    AudioSource audiosource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "bullet")
        {
            //遭bullet射擊音效
            audiosource.Play();

            //遭bullet射擊動畫
            if (gameObject.tag == "monster")
            {
                anim.Play("monsterAttackedRun");
                Invoke("AnimPlay", 2f);
            }
            else if (gameObject.tag == "monsterSky")
            {
                anim.Play("monsterSkyAttackedRun");
                Invoke("AnimPlay", 2f);
            }

            //遭bullet射擊，扣怪物血量
            monsterHp -= damage;
            //monsterHpText.text = monsterHp.ToString();
            monsterHpImg.fillAmount = monsterHp * 0.1f;

            //當monster血量為0，Invoke "DestroyMonster"
            if (monsterHp <= 0)
            {
                Invoke("DestroyMonster", 0.1f);
            }
        }

        //monster與gate碰撞後，銷毀monster
        if (collision.transform.tag == "gate")
        {
            Destroy(gameObject);
        }
    }

    //正常怪物跑步動畫
    public void AnimPlay()
    {
        if (gameObject.tag == "monster")
        {
            anim.Play("monsterRun");
        }
        else if (gameObject.tag == "monsterSky")
        {
            anim.Play("monsterSkyRun");
        }
    }

    void DestroyMonster()
    {
        //取得GameManager，當擊敗怪物時，killCounter++
        GameManager getGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        getGameManager.killCounter++;
        getGameManager.killCounterNowText.text = " 擊敗怪物數：" + getGameManager.killCounter;
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();

        //設定怪物血量
        monsterHp = 10;
        //monsterHpText.text = monsterHp.ToString();

        //設定bullet攻擊傷害
        damage = 1;

        //取得MonsterGenerate的Level來更改怪物的移動速度
        MonsterGenerate getMonsterGenerate = GameObject.Find("MonsterGenerate").GetComponent<MonsterGenerate>();
        if (getMonsterGenerate.level == "Level4")
        {
            moveSpeed = 150f;
            moveSpeedSky = 170f;
        }
        else if (getMonsterGenerate.level == "Level5")
        {
            moveSpeed = 170f;
            moveSpeedSky = 190f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //怪物移動
        if (gameObject.tag == "monster")
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        else if (gameObject.tag == "monsterSky")
        {
            transform.position = new Vector2(transform.position.x - moveSpeedSky * Time.deltaTime, transform.position.y);
        }
    }
}
