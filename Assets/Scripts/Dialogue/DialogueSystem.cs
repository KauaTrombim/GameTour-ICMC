using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class DialogueSystem : MonoBehaviour
{
    public DialogueData dialogueData;

    int currentTextIndex = 0;
    bool isFinished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    STATE state;

    void Awake()
    {
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinished;
    }

    public void Next()
    {
        if(currentTextIndex == 0)
        {
            dialogueUI.Enable();

        }

        dialogueUI.SetName(dialogueData.talkScript[currentTextIndex].name);

        typeText.fullText = dialogueData.talkScript[currentTextIndex++].text;
        
        if(currentTextIndex == dialogueData.talkScript.Count) isFinished = true; //verifica se o dialogo acabou

        typeText.StartTyping(); //Inicia a animação
        state = STATE.TYPING;
    }

    void Start()
    {
        state = STATE.DISABLED;
        dialogueUI.Disable();
    }

    void Update()
    {
        if (state == STATE.DISABLED) return;

        switch (state) 
        {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
        }

    }

    void OnTypeFinished()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isFinished)
            {
                Next();
            }
            else
            {
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentTextIndex = 0;
                isFinished = false;
            }
        }
    }
    void Typing() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
