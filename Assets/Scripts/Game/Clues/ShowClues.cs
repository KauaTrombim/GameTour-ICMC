using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowClues : MonoBehaviour
{
    Image press_e;
    Image press_r;
    CanvasGroup canvasGroupE;
    CanvasGroup canvasGroupR;

    // Start is called before the first frame update
    void Start()
    {
        press_e = transform.GetChild(0).GetComponent<Image>();
        press_r = transform.GetChild(1).GetComponent<Image>();

        canvasGroupE = press_e.GetComponent<CanvasGroup>();
        canvasGroupR = press_r.GetComponent<CanvasGroup>();
        canvasGroupE.alpha = 0;
        canvasGroupR.alpha = 0;
    }

    public void showClueE()
    {
        canvasGroupE.alpha = 1;
        canvasGroupE.interactable = true;
        canvasGroupE.blocksRaycasts = true;
    }

    public void hideClueE()
    {
        canvasGroupE.alpha = 0;
        canvasGroupE.interactable = false;
        canvasGroupE.blocksRaycasts = false;
    }

    public void showClueR()
    {
        canvasGroupR.alpha = 1;
        canvasGroupR.interactable = true;
        canvasGroupR.blocksRaycasts = true;
    }
    public void hideClueR()
    {
        canvasGroupR.alpha = 0;
        canvasGroupR.interactable = false;
        canvasGroupR.blocksRaycasts = false;
    }
}
