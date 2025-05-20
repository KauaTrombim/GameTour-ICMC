using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum STATE
{
    DISABLED,
    WAITING,
    TYPING
}

public class DialogueSystem : MonoBehaviour
{
    //Dialogo
    public List<DialogueData> dialogueData;
    DialogueData currentScreenPlay;
    private string npcName;

    //Eventos
    public static event Action<string> dialogueStart;
    public static event Action<string> dialogueEnd;

    int currentTextIndex = 0;
    bool isFinished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;
    Player player;

    public STATE state;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        typeText = FindObjectOfType<TypeTextAnimation>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        
        typeText.TypeFinished = OnTypeFinished;
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
    public void TalkTo(string npc_Name)
    {
        dialogueUI.Enable();
        player.canWalk = false;
        npcName = npc_Name;
        dialogueStart?.Invoke(npcName);
        
        string dialogo;
        switch (npcName)
        {
            case "Manzato":
                dialogo = "Atari";
                break;
            case "Claudio":
                dialogo = "ComputerSpace";
                break;
            default:
                Debug.Log("Invalid");
                dialogo = "";
                return;
                break;
        }

        for (int i = 0; i < dialogueData.Count; i++)
        {
            if (dialogueData[i].name == dialogo)
            {
                this.currentScreenPlay = dialogueData[i];
                Next();
            }
        }
    }

    void Next()
    {
        if (currentScreenPlay != null)
        {
            string path = "Sprite/characters/inUI/" + npcName;
            Sprite sprite = Resources.Load<Sprite>(path);

            if (currentScreenPlay.talkScript[currentTextIndex].name == "Você")
            {
                dialogueUI.photo.sprite = null;
            }
            else
            {
                dialogueUI.photo.sprite = sprite;
            }



            
            dialogueUI.SetName(currentScreenPlay.talkScript[currentTextIndex].name);
            typeText.fullText = currentScreenPlay.talkScript[currentTextIndex++].text;
            
            


            if (currentTextIndex == currentScreenPlay.talkScript.Count) isFinished = true; //verifica se o dialogo acabou

            typeText.StartTyping(); //Inicia a animação
            state = STATE.TYPING;
        }
    }

    void OnTypeFinished()
    {
        state = STATE.WAITING;
    }

    void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.canAct)
        {
            if (!isFinished)
            {
                Next();
            }
            else
            {
                dialogueUI.Disable();
                player.canWalk = true;
                state = STATE.DISABLED;
                currentTextIndex = 0;
                isFinished = false;
                currentScreenPlay = null;
                dialogueEnd?.Invoke(npcName);
            }
        }
    }
    void Typing() 
    {
        if (Input.GetKeyDown(KeyCode.E) && player.canAct)
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
