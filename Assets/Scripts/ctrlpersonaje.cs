using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrlpersonaje : MonoBehaviour
{ //Declaración de variables: 
	Rigidbody2D rgb;
	Animator anim;
	AudioSource aSource;
	public float maxVel = 5f;
	bool haciaDerecha = true;
	public Slider slider;
	public Text txtSalud;
	public int energy;
	public GameObject retroalimentacionEnergiaPrefab;
	Transform retroalimentacionSpawnPoint;

	public AudioClip cortandoUnArbol;
	public AudioClip ouch;
	public AudioClip dying;


	public int costoGolpeAlAire = 1;
	public int costoGolpeAlArbol = 3;
	public int premioArbol = 15;
	

	bool enFire1 = false;

	//CtrlArbol ctrArbol = null;
	GameObject hacha = null;

	public bool jumping = false;
	public bool isOnTheFloor = false;
	public float yJumpForce = 300;
	Vector2 jumpForce;

	void Start()
    {//Inicialización
		rgb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		//aSource = GetComponent<AudioSource>();
		hacha = GameObject.Find("/orc/orc_body/orc _R_arm/orc _R_hand/orc_weapon");
		//retroalimentacionSpawnPoint = GameObject.Find("spawnPoint").transform;
		energy = 100;
		jumpForce = new Vector2(0, 0);
		rgb.freezeRotation = true;
	}

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        VerificarInputParaCaminar();
        VerificarInputParaSaltar();

}
    private void VerificarInputParaCaminar()
    {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        v *= maxVel;
        vel.x = v;
        rgb.velocity = vel;
        Debug.DrawLine(transform.position,
                        transform.position + new Vector3(vel.x, vel.y));
        //anim.SetFloat ("speed", vel.x);

        if (haciaDerecha && v < 0)
        {
            haciaDerecha = false;
            Flip();
        }
        else if (!haciaDerecha && v > 0)
        {
            haciaDerecha = true;
            Flip();
        }
    }

    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    public void VerificarInputParaSaltar()
    {
        // Variable corregir el error del salto infinito
        isOnTheFloor = rgb.velocity.y == 0;

        if (Input.GetAxis("Jump") > 0.01f)// ||
                                          // Nueva tecla para el salto
                                          //Input.GetKeyDown(KeyCode.UpArrow))
        {
            // ahora solo puede saltar si la velocidad del RGB es 0 en su componente 'y' es decir que no este cayendo o subiendo.
            if (!jumping && isOnTheFloor)
            {
                jumping = true;
                jumpForce.x = 0f;
                jumpForce.y = yJumpForce;
                rgb.AddForce(jumpForce);
            }
        }
        else
            jumping = false; // por el momento... esto debe ser despu'es de terminar la animaci'on
    }

   

//fin
}
