using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerate : MonoBehaviour
{
    [Header("Monster")]
    public GameObject monster;                     //monster Prefab
    public GameObject monsterGeneratePosition;     //monster生成位置
    public GameObject monsterSky;                  //monsterSky Prefab
    public GameObject monsterSkyGeneratePosition;  //monsterSky 生成位置
    float monsterGenerateTime;                     //生成間隔時間
    int invokeTime;                                //生成次數

    [Space(10)]
    [Header("Level")]
    public string level;
        
    //判斷當前Level是否為第一隻怪物生成
    bool isFirst = true;

    int isPause = 0;    //判斷是否暫停中，0為非暫停，1為暫停中
    float timeCounter;  //計算暫停秒數

    //儲存當前Level
    public void SaveLevel(string savelevel)
    {
        level = savelevel;
    }

    #region Levels
    public void Level1()
    {
        isFirst = false;    //非第一次生成怪物
        timeCounter = 0f;   //每生成一隻怪物即重新計算經過秒數
        invokeTime++;       //計算已生成幾隻怪物
        Debug.Log(level + " " + invokeTime);
        
        //生成怪物
        Instantiate(monster, monsterGeneratePosition.transform);

        if (invokeTime >= 5)    //當生成5隻怪物後，即進入Level2
        {
            isFirst = true;
            SaveLevel("Level2");    //儲存當前Level
            invokeTime = 0;         //清除已生成怪物數
            InvokeRepeating("Level2", 3f, GetGenerateTime(level));  //開始Level2
            CancelInvoke("Level1"); //暫停Level1
        }
    }

    public void Level2()
    {
        isFirst = false;    //非第一次生成怪物
        timeCounter = 0f;   //每生成一隻怪物即重新計算經過秒數
        invokeTime++;       //計算已生成幾隻怪物
        Debug.Log(level + " " + invokeTime);

        //生成怪物
        Instantiate(monsterSky, monsterSkyGeneratePosition.transform);

        if (invokeTime >= 5)    //當生成5隻怪物後，即進入Level3
        {
            isFirst = true;
            SaveLevel("Level3");    //儲存當前Level
            invokeTime = 0;         //清除已生成怪物數

            //開始Level3 & 3_1
            InvokeRepeating("Level3", 3f, GetGenerateTime(level));
            InvokeRepeating("Level3_1", 4f, GetGenerateTime(level) + 2);
            CancelInvoke("Level2"); //暫停Level2
        }
    }

    public void Level3()
    {
        isFirst = false;    //非第一次生成怪物
        timeCounter = 0f;   //每生成一隻怪物即重新計算經過秒數
        invokeTime++;       //計算已生成幾隻怪物
        Debug.Log(level + " " + invokeTime);

        //生成怪物
        Instantiate(monster, monsterGeneratePosition.transform);

        if(invokeTime >= 15)    //當生成15隻怪物後，即進入Level4
        {
            isFirst = true;
            SaveLevel("Level4");    //儲存當前Level
            invokeTime = 0;         //清除已生成怪物數

            //開始Level4 & 4_1
            InvokeRepeating("Level4", 3f, GetGenerateTime(level));
            InvokeRepeating("Level4_1", 4f, GetGenerateTime(level) + 2);
            //暫停Level3 & 3_1
            CancelInvoke("Level3");
            CancelInvoke("Level3_1");
        }
    }

    public void Level3_1()
    {
        //生成怪物
        Instantiate(monsterSky, monsterSkyGeneratePosition.transform);
    }

    public void Level4()
    {
        isFirst = false;    //非第一次生成怪物
        timeCounter = 0f;   //每生成一隻怪物即重新計算經過秒數
        invokeTime++;       //計算已生成幾隻怪物
        Debug.Log(level + " " + invokeTime);

        //生成怪物
        Instantiate(monster, monsterGeneratePosition.transform);

        if (invokeTime >= 20)    //當生成20隻怪物後，即進入Level5
        {
            isFirst = true;
            SaveLevel("Level5");    //儲存當前Level
            invokeTime = 0;         //清除已生成怪物數

            //開始Level5 & 5_1
            InvokeRepeating("Level5", 3f, GetGenerateTime(level));
            InvokeRepeating("Level5_1", 4f, GetGenerateTime(level) + 2);
            //暫停Level4 & 4_1
            CancelInvoke("Level4");
            CancelInvoke("Level4_1");
        }
    }

    public void Level4_1()
    {
        //生成怪物
        Instantiate(monsterSky, monsterSkyGeneratePosition.transform);
    }

    public void Level5()
    {
        isFirst = false;    //非第一次生成怪物
        timeCounter = 0f;   //每生成一隻怪物即重新計算經過秒數
        invokeTime++;       //計算已生成幾隻怪物
        Debug.Log(level + " " + invokeTime);

        //生成怪物
        Instantiate(monster, monsterGeneratePosition.transform);
    }

    public void Level5_1()
    {
        //生成怪物
        Instantiate(monsterSky, monsterSkyGeneratePosition.transform);
    }
    #endregion

    //根據Level回傳生成間隔時間
    public float GetGenerateTime(string level)
    {
        float generateTime;
        if (level == "Level1")
        {
            generateTime = 8f;
        }
        else if (level == "Level2")
        {
            generateTime = 8f;
        }
        else if (level == "Level3")
        {
            generateTime = 5f;
        }
        else if (level == "Level4")
        {
            generateTime = 4f;
        }
        else if (level == "Level5")
        {
            generateTime = 3f;
        }
        else
        {
            generateTime = 10f;
        }
        return generateTime;
    }

    // Use this for initialization
    void Start()
    {
        SaveLevel("Level1");

        //開始Level1
        InvokeRepeating("Level1", 3f, GetGenerateTime(level));
    }

    public void PauseGame()
    {
        isPause = 1;
        CancelInvoke(level);    //取消目前Level
        Debug.Log("cancel " + level + " isPause " + isPause);
    }

    public void ContinueGame()
    {
        isPause = 0;
        if (isFirst)    //若當前Level尚未生成第一隻怪物
        {
            InvokeRepeating(level, 3f, GetGenerateTime(level));
        }
        else    //若當前Level已生成第一隻怪物，則依怪物生成間隔時間扣除經過秒數來決定首次生成怪物時間
        {
            InvokeRepeating(level, GetGenerateTime(level) - timeCounter, GetGenerateTime(level));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause == 0) //計算經過秒數
        {
            timeCounter += Time.deltaTime;
            //Debug.Log(level + " " + timeCounter);
        }
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
