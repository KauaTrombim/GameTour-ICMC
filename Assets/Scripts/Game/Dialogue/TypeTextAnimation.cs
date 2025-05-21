using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeTextAnimation : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    public Action TypeFinished;

    public string fullText;

    Coroutine coroutine;

    DialogueUI dialogueUI;

    void Start()
    {
        dialogueUI = FindObjectOfType<DialogueUI>();
    }

    public void StartTyping()
    {
        coroutine = StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textObject.text = fullText; //atribui o texto ao gameObject
        textObject.maxVisibleCharacters = 0; //Torna os caracteres invisiveis

        //Insere caractere por caractere na tela
        for(int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay); //Aciona o delay definido no inicio do programa
        }

        TypeFinished?.Invoke();
    }

    public void Skip(){
        StopCoroutine(coroutine);
        textObject.maxVisibleCharacters = textObject.text.Length;
        dialogueUI.backgroud.fillAmount = 1;
    }
}
