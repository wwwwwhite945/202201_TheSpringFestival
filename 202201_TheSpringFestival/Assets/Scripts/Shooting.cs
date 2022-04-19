using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;   //子彈Prefab
    public GameObject soldier;  //子彈生成位置

    AudioSource audiosource;

    // Use this for initialization
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //使用者輸入-GetKey
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("按下空白鍵射擊");
            Instantiate(bullet, new Vector2(soldier.transform.position.x + 100, soldier.transform.position.y), Quaternion.identity, GameObject.FindGameObjectWithTag("canvas").transform);
        }
        */

        //使用者輸入-GetButton
        if (Input.GetButtonDown("Fire1"))
        {
            //子彈發射音效
            audiosource.Play();
            
            //生成子彈，生成位置在soldier前方，生成在bulletGenerate下
            Instantiate(bullet, new Vector2(soldier.transform.position.x + 100, soldier.transform.position.y), Quaternion.identity, GameObject.FindGameObjectWithTag("bulletGenerate").transform);
        }
    }
}
