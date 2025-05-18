using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Inputs publicos
    public float Speed;
    public float dialogueDistance; //distânica para consversar com npc

    //Dialogo
    public List<GameObject> NPCS;
    DialogueSystem dialogueSys;
    ShowClues showClues;


    //Movimentação
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        dialogueSys = FindObjectOfType<DialogueSystem>();
        showClues = FindObjectOfType<ShowClues>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Walk();

        SearchNPC();
    }

    private void SearchNPC()
    {
        Vector2 playerPosition = transform.position;

        foreach(GameObject npc in NPCS)
        {
            //Debug.Log(npc.name.GetType());
            Vector2 npcPosition = npc.transform.position;
            float distance = Vector2.Distance(playerPosition, npcPosition);

            //area de diálogo com o NPC
            if (distance <= dialogueDistance && dialogueSys.state == STATE.DISABLED)
            {
                showClues.showClueE();

                //Aciona o diálogo
                if (Input.GetKeyDown(KeyCode.R))
                {
                    dialogueSys.TalkTo(npc.name);
                    showClues.hideClueE();
                }
            }
            else
            {
                showClues.hideClueE();
            }
        }
    }

    private void Walk()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * Speed;

        animationChange(direction);
    }

    private void animationChange(Vector2 dir)
    {
        if (dir.x != 0)
        {
            resetLayer();

            //Direita e Esquerda, respectivamente
            if (dir.x > 0)
            {
                anim.SetLayerWeight(3, 1);
            }
            else
            {
                anim.SetLayerWeight(2, 1);
            }
        }

        if (dir.y > 0 && dir.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(1, 1);
        }
        if (dir.y < 0 && dir.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(0, 1);
        }

        //Alteração da variável
        if (dir != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private void resetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
        anim.SetLayerWeight(3, 0);
    }
}
