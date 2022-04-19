using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldier : MonoBehaviour
{
    Rigidbody2D rb; //Rigibody 透過物理模擬控制物件位置

    //public float move;
    [Header("Soldier跳躍高度")]
    public float jump;      //Soldier跳躍高度
    bool isJumping;         //判斷是否正在跳躍
    
    [Space(10)]
    [Header("Soldier圖片更換")]
    public Image soldierImg;    
    public Sprite[] soldierSpr;

    AudioSource audiosource;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;

        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //AD左右移動
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(move, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-move, 0);
        }
        */

        //WS上下移動
        if (Input.GetKey(KeyCode.W) && isJumping == false) //控制在非跳躍狀態下才可以進行跳躍
        {
            //Soldier跳躍音效
            audiosource.Play();

            rb.velocity = new Vector2(0, jump);
            isJumping = true;
            soldierImg.sprite = soldierSpr[1];  //跳躍時更換圖片為跳躍動作
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -jump);
            soldierImg.sprite = soldierSpr[0];  //非跳躍時更換圖片為站立動作
        }
    }


    //當Soldier碰撞到floor時，即可再次跳躍
    private void OnCollisionEnter2D(Collision2D collision) //兩個物件碰撞瞬間，執行一次函式
    {
        if (collision.gameObject.tag == "floor")
        {
            isJumping = false;
            soldierImg.sprite = soldierSpr[0];
        }
    }
    private void OnCollisionStay2D(Collision2D collision) //兩個物件保持接觸，不斷執行函式
    {
        if (collision.gameObject.tag == "floor")
        {
            isJumping = false;
            soldierImg.sprite = soldierSpr[0];
        }
    }
}
