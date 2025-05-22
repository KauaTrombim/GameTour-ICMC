using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoviment: MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float maxDistance;

    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);

        if (transform.position.y >= 13.22)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Player")
        {
            Debug.Log("Bati");
            Destroy(gameObject);
        }

    }
}
