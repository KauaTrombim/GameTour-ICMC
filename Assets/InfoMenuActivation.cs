using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenuActivation : MonoBehaviour
{
    public GameObject player;
    public GameObject booths;

    Player playerScript;
    ShowClues showClues;

    public float readDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.playerScript = player.GetComponent<Player>();
        showClues = FindObjectOfType<ShowClues>();
    }

    void Update()
    {
        bool boothFound = false;

        foreach (Transform booth in booths.transform)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 boothPosition = booth.transform.position;
            float distance = Vector2.Distance(boothPosition, playerPosition);
            if (distance <= readDistance)
            {
                playerScript.canRead = true;
                boothFound = true;
                break;
            }
        }
        if (!boothFound)
        {
            playerScript.canRead = false;
            boothFound = false;
        }
    }
}
