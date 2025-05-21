using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuManager : MonoBehaviour
{
    [SerializeField]
    private string mainGameScene;

    public void Play()
    {
        SceneManager.LoadScene(mainGameScene);
    }
    public void Quit()
    {
        Application.Quit();

        //Fecha o jogo no editor
        #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
        #endif  
    }
}
