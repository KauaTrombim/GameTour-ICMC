using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barataNormal : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bateu");
        sr.sprite = null;
        anim.enabled = false;
    }
}
