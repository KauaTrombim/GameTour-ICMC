using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    //Itens do dialogo
    public Image backgroud;
    public Image photo;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;

    //Auxiliares
    public float speed = 10f;
    bool open = false;
    CanvasGroup canvasGroup;

    void Awake()
    {
        backgroud = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        photo = transform.GetChild(3).GetComponent<Image>();

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0; //Inicia a caixa já fechada
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
        photo.fillAmount = 0;
        open = true;

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Disable() 
    {
        open = false;
        nameText.text = "";
        talkText.text = "";

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
