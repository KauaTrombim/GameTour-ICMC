using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWindow : MonoBehaviour
{
    public GameObject infos;
    CanvasGroup infosCG;
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        infosCG = infos.GetComponent<CanvasGroup>();
        infosCG.alpha = 0;
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                hideInfoWindow();
                isActive = false;
            }
        }
    }

    public void showInfoWindow()
    {
        infosCG.alpha = 1;
        infosCG.interactable = true;
        infosCG.blocksRaycasts = true;
        Debug.Log("Abriu");
    }
    public void hideInfoWindow()
    {
        infosCG.alpha = 0;
        infosCG.interactable = false;
        infosCG.blocksRaycasts = false;
    }
}
