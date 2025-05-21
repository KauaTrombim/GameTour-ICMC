using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAreaCheck : MonoBehaviour
{
    public GameObject player;
    public GameObject NPCS;
    Player playerScript;


    public float dialogueDistance; //distânica para consversar com npc



    // Start is called before the first frame update
    void Start()
    {
        this.playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        bool npcFound = false;

        foreach (Transform npc in NPCS.transform)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 npcPosition = npc.transform.position;
            float distance = Vector2.Distance(npcPosition, playerPosition);
            if (distance <= dialogueDistance)
            {
                playerScript.canTalk = true;
                playerScript.npcName = npc.name;
                npcFound = true;
                break;
            }
        }
        if (!npcFound)
        {
            playerScript.canTalk = false;
            playerScript.npcName = null;
            npcFound = false;
        }


    }
}
