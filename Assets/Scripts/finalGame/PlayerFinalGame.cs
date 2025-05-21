using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalGame : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.velocity = direction * Speed;

        //changeConveyorBelt();
    }
}
