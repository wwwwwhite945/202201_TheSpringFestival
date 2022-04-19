using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBtn : MonoBehaviour
{
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BtnPressing()   //按下按鈕時播放按鈕音效
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
