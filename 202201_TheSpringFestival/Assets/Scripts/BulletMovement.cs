using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //bullet移動速度
    float moveSpeed = 200f;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //從MonsterGenerate取得目前Level來更改bullet速度
        MonsterGenerate getMonsterGenerate = GameObject.Find("MonsterGenerate").GetComponent<MonsterGenerate>();
        if (getMonsterGenerate.level == "Level4")
        {
            moveSpeed = 250;
        }
        else if (getMonsterGenerate.level == "Level5")
        {
            moveSpeed = 300;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bullet移動
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //bullet與wall碰撞即銷毀，避免生成過多bullet
        if (collision.transform.tag == "wall")
        {
            Destroy(gameObject);
        }
        //bullet與怪物碰撞，播放音效及銷毀bullet
        if (collision.transform.tag == "monster")
        {
            audioSource.Play();
            Destroy(gameObject);
        }
        if (collision.transform.tag == "monsterSky")
        {
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
