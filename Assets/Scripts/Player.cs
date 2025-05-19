using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Inputs publicos
    public float Speed;

    //Dialogo
    public GameObject NPCS;
    DialogueSystem dialogueSys;
    ShowClues showClues;
    public string npcName;
    public bool canTalk = false;
    public bool inputBlocked = false;

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

    private void Update()
    {
        Walk();

        SearchNPC();
    }

    private void SearchNPC()
    {
        if (canTalk && dialogueSys.state == STATE.DISABLED)
        {
            showClues.showClueE();

            //Aciona o diálogo
            if (!inputBlocked && Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(SetDelay(0.2f));
                dialogueSys.TalkTo(npcName);
                showClues.hideClueE();
            }
        }
        else
        {
            showClues.hideClueE();
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
            ResetLayer();

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
            ResetLayer();
            anim.SetLayerWeight(1, 1);
        }
        if (dir.y < 0 && dir.x == 0)
        {
            ResetLayer();
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

    private void ResetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
        anim.SetLayerWeight(3, 0);
    }

    IEnumerator SetDelay(float delay)
    {
        inputBlocked = true;
        yield return new WaitForSeconds(delay);
        inputBlocked = false;
    }
}
