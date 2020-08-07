using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctrlhacha : MonoBehaviour
{//Declaración de variables:
    ctrlpersonaje ctr;
    
    void Start()
    {//Inicialización:
        ctr = GameObject.Find("orc").GetComponent<ctrlpersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Arbol"))
        {
            ctr.SetControlArbol(other.gameObject.GetComponent<ctrlarbol>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Arbol"))
        {
            ctr.SetControlArbol(null);
        }
    }

    //Fin
}
