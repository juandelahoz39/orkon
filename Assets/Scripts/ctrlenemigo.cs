using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlenemigo : MonoBehaviour
{//Declaración de variables:
    public float vel = -1f;
    Rigidbody2D rgb;
    Animator anim;

    //vida del personaje:
    public Slider slider;
    public Text txt;
    public float energy = 10;
    public int golpeDelOrco = 3;

    AudioSource aSource;
    public AudioClip dying;

    void Start()
    {//Inicialización:
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Flip();
    }

    void Flip()
    {
        vel *= -1;
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    //Fin
}
