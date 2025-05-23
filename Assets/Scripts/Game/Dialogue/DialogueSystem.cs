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
    public string[] npcs = new string[8];

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

        if (Input.GetKeyDown(KeyCode.Escape) && state != STATE.DISABLED){
            CloseAll();
        }

    }
    public void TalkTo(string npc_Name)
    {
        dialogueUI.Enable();
        player.canWalk = false;
        npcName = npc_Name;
        dialogueStart?.Invoke(npcName);

        for(int i = 0; i < npcs.Length; i++) 
        {
            if (npcs[i] == npcName)
            {
                this.currentScreenPlay = dialogueData[i];
            }
        }

        Next();
    }

    void Next()
    {
        if (currentScreenPlay != null)
        {
            string path;
            if (currentScreenPlay.talkScript[currentTextIndex].name == "Voc�")
            {
                path = "Sprite/characters/inUI/Pmale";
            }
            else
            {
                path = "Sprite/characters/inUI/"+ npcName;
            }

             
            Sprite sprite = Resources.Load<Sprite>(path);

            dialogueUI.photo.sprite = sprite;
            dialogueUI.SetName(currentScreenPlay.talkScript[currentTextIndex].name);
            typeText.fullText = currentScreenPlay.talkScript[currentTextIndex++].text;
            
            if (currentTextIndex == currentScreenPlay.talkScript.Count) isFinished = true; //verifica se o dialogo acabou

            typeText.StartTyping(); //Inicia a anima��o
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
                CloseAll();
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

    void CloseAll()
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
