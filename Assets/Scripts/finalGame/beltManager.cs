using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beltManager : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void moveBelt(Vector2 direction)
    {
        //direita
        if (direction.x < 0)
        {
            ResetLayer();
            anim.SetBool("beltMoving", true);
            anim.SetLayerWeight(1, 1);
        }
        //esquerda
        else if(direction.x > 0)
        {
            ResetLayer();
            anim.SetBool("beltMoving", true);
            anim.SetLayerWeight(0, 1);
        }
        else
        {
            ResetLayer();
            anim.SetBool("beltMoving", false);
        }
    }

    private void ResetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
    }

}
