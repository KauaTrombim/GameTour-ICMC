using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuActivation : MonoBehaviour
{
    private bool isPaused = false;

    [Header("Paineis e Menu")]
    public GameObject pausePanel;
    public string scene;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Continue();
            }
        }
    }

    void Pause()
    {
        //Bloqueia a tela
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        
        //Bloqueia o personagem
        player.canAct = false;

        //Cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Continue()
    {
        //Libera a tela
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

        //Libera o personagem
        player.canAct = true;

        //Cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
