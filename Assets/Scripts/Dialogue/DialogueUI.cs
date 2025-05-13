using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    Image backgroud;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;

    public float speed = 10f;
    bool open = false;

    void Awake()
    {
        backgroud = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (open)
        {
            backgroud.fillAmount = Mathf.Lerp(backgroud.fillAmount, 1, speed * Time.deltaTime);
        }
        else {
            backgroud.fillAmount = Mathf.Lerp(backgroud.fillAmount, 0, speed * Time.deltaTime);
        }
    }

    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void Enable()
    {
        backgroud.fillAmount = 0;
        open = true;
    }

    public void Disable() 
    {
        open = false;
        nameText.text = "";
        talkText.text = "";
    }
}
