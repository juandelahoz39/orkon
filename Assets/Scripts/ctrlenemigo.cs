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
    public GameObject retroalimentacionEnergiaPrefab;
    Transform retroalimentacionSpawnPoint;

    AudioSource aSource;
    public AudioClip dying;

    void Start()
    {//Inicialización:
        rgb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        retroalimentacionSpawnPoint = GameObject.Find("spawnPoint").transform;
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (energy <= 0)
        {
            energy = 0;
            gameObject.SetActive(false);
        }
        slider.value = energy;
        txt.text = energy.ToString();
    }

    private void FixedUpdate()
    {
        Vector2 v = new Vector2(vel, 0);
        rgb.velocity = v;
    }

    private void IncrementarEnergia(int incremento)
    {
        energy += incremento;
        InstanciarRetroalimentacionEnergia(incremento);
    }

    private void InstanciarRetroalimentacionEnergia(int incremento)
    {
        GameObject retroalimentcionGO = null;
        if (retroalimentacionSpawnPoint != null)
            retroalimentcionGO = (GameObject)Instantiate(retroalimentacionEnergiaPrefab, retroalimentacionSpawnPoint.position, retroalimentacionSpawnPoint.rotation);
        else
            retroalimentcionGO = (GameObject)Instantiate(retroalimentacionEnergiaPrefab, transform.position, transform.rotation);

        retroalimentcionGO.GetComponent<RetroalimentacionEnergia>().cantidadCambiodeEnergia = incremento;
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


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("orc"))
        {
            if (energy > 0)
            {
                //energy -= golpeDelOrco;
                IncrementarEnergia(golpeDelOrco * -1);
            }
            else
            {
                gameObject.SetActive(false);
            }
            //Fin contacto bombak
        }
        slider.value = energy;
        txt.text = energy.ToString();
    }


    //Fin
}
