using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlarbol : MonoBehaviour
{//Declaración de variables:

    public int numGolpesParaCaer = 3;
    Animator anim;

    void Start()
    {//Inicialización:
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GolpeOrco()
    {
        bool resp = false;
        numGolpesParaCaer--;
        if (numGolpesParaCaer <= 0)
        {
            anim.SetTrigger("Caer");
            resp = true;

        }
        return resp;
    }

    //Fin
}
