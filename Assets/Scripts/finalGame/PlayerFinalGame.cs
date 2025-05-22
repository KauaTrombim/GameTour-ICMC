using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinalGame : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public float Speed;
    float fireRate = 0.5f;
    float nextFire;

    beltManager beltManagement;

    [SerializeField]
    GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        beltManagement = FindObjectOfType<beltManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();

        if (Input.GetKeyDown(KeyCode.W) && Time.time >= nextFire)
        {
            Shot();
        }
    }

    void Walk()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.velocity = direction * Speed;
        beltManagement.moveBelt(direction);
    }
    void Shot()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        nextFire = Time.time + fireRate;
        Debug.Log("Atirei");
    }
}
