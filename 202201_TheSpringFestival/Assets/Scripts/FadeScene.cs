using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    public GameObject FadeImgObj;
    public Image FadeImg;
    float alpha;
    string nextSceneName;

    // Use this for initialization
    void Start()
    {
        FadeImgObj = GameObject.Find("fadeInOut");
        FadeImg = FadeImgObj.GetComponent<Image>();
        FadeImgObj.SetActive(true);
        StartCoroutine(FadeInScene());
    }

    public void FadeToScene(string sceneName)
    {
        nextSceneName = sceneName;
        if (nextSceneName != "")
        {
            StartCoroutine(FadeOutScene());
        }
    }

    IEnumerator FadeInScene()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            FadeImg.color = new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(0);
        }
        FadeImgObj.SetActive(false);
    }

    IEnumerator FadeOutScene()
    {
        FadeImgObj.SetActive(true);
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            FadeImg.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
