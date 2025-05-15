using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Inputs publicos
    public float Speed;

    //Dialogo
    DialogueSystem dialogueSys;
    GameObject manzato;
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
        manzato = GameObject.FindWithTag("Manzato");
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * Speed;

        Vector2 playerPosition = transform.position;
        Vector2 manzatoPosition = manzato.transform.position;
        float distance = Vector2.Distance(playerPosition, manzatoPosition);

        animationChange(direction);

        //area de diálogo com o manzato
        if(distance <= 4f)
        {
            showClues.showClueE();
            //Aciona o diálogo
            if (Input.GetKeyDown(KeyCode.R))
            {
                dialogueSys.Next();
            }
        }
        else
        {
            showClues.hideClueE();
        }
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
