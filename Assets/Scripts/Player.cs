using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    DialogueSystem dialogueSys;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    void Awake()
    {
        dialogueSys = FindObjectOfType<DialogueSystem>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = direction.normalized * Speed;

        if(direction.x != 0)
        {
            resetLayer();

            //Direita e Esquerda, respectivamente
            if (direction.x > 0)
            {
                anim.SetLayerWeight(3, 1);
            }
            else
            {
                anim.SetLayerWeight(2, 1);
            }
        }

        if(direction.y > 0 && direction.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(1, 1);
        }
        if (direction.y < 0 && direction.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(0, 1);
        }

        if (direction != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            dialogueSys.Next();
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
