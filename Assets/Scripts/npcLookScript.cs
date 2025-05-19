using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcLookScript : MonoBehaviour
{
    public GameObject player;
    public GameObject NPCS;
    Player playerScript;
    DialogueAreaCheck areaCheck;

    public bool dialogueStart;
    public string npcName;
    GameObject npc;
    public Sprite[] spriteList;

    // Start is called before the first frame update
    void Start()
    {
        this.playerScript = player.GetComponent<Player>();
        this.areaCheck = FindObjectOfType<DialogueAreaCheck>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueStart)
        {
            npc = NPCS.transform.Find(npcName).gameObject;
            searchSprite(npcName);
        }
    }

    void LookAtPlayer()
    {

    }

    void DefaultLook()
    {

    }

    void searchSprite()
    {
        string path = "Sprites/characters/" + npcName;
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>(path);

        spriteList = new Sprite[4];
        for (int i = 0; i < 4; i++)
        {
            spriteList[i] = loadedSprites[i];
        }

    }
}
