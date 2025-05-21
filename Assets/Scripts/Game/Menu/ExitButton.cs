using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    [SerializeField]
    private string mainMenuScene;

    public void ExitGame()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}