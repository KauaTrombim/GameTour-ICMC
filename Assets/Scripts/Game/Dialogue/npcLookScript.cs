using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcLookScript : MonoBehaviour
{
    public GameObject player;
    public GameObject NPCS;
    public Sprite[] spriteList;

    private SpriteRenderer spriteNPC;
    private GameObject currentNPC;

    // Start is called before the first frame update
    void Start()
    {
        DialogueSystem.dialogueStart += LookAtPlayer;
        DialogueSystem.dialogueEnd += DefaultLook;
    }

    void LookAtPlayer(string npcName)
    {


        searchSprite(npcName);

        Transform npc = NPCS.transform.Find(npcName);
        currentNPC = npc.gameObject;
        spriteNPC = currentNPC.GetComponent<SpriteRenderer>();

        Vector2 playerDirection = player.transform.position - currentNPC.transform.position;

        if (Mathf.Abs(playerDirection.x) > Mathf.Abs(playerDirection.y))
        {
            spriteNPC.sprite = playerDirection.x > 0 ? spriteList[2] : spriteList[3];
        }
        else
        {
            spriteNPC.sprite = playerDirection.y > 0? spriteList[0]: spriteList[1];
        }
    }

    void DefaultLook(string npcName)
    {
        searchSprite(npcName);
        SpriteRenderer spriteNPC = currentNPC.GetComponent<SpriteRenderer>();

        spriteNPC.sprite = spriteList[1];
    }

    void searchSprite(string name)
    {
        string path = "Sprite/characters/inGame/" + name;
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>(path);

        spriteList = new Sprite[4];
        for (int i = 0; i < 4; i++)
        {
            spriteList[i] = loadedSprites[i];
        }

    }
}
