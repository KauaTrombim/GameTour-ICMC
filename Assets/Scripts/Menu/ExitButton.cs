using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

        //Fecha o jogo no editor
    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}