using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ckrtMovimentAndColision : MonoBehaviour
{
    private float speed;
    public float step = 0.005f;
    public float expTime = 0.6f;

    SpriteRenderer sr;
    Animator anim;
    Collider2D colision;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        colision = GetComponent<Collider2D>();
        anim.SetBool("isAlive", true);
    }
    void Update()
    {
        Walk();
    }


    async void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bateu em "+ other.name);
        colision.enabled = false;
        anim.SetBool("isAlive", false);
        Destroy(gameObject, expTime);
    }

    async Task Walk()
    {
        Vector2 dir = transform.position;
        dir.y -= step;
        transform.position = dir;
        await Task.Delay(5000);
    }
}
