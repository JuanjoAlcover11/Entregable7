using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float jumpforce = 20f;
    private float downforce = 3f;
    public int counter = 0;
    private float gravityModifier = 1;
    private float upLim = 14f;
    private float downLim = 0f;

    public bool gameOver;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem moneyParticleSystem;

    private AudioSource playerAudioSource;
    private AudioSource explosionAudioSource;
    private AudioSource moneyAudioSource;
    private AudioSource cameraAudioSource;
    public AudioClip boingClip;
    public AudioClip blipClip;
    public AudioClip boomClip;

    void Start()
    {
       // Accedemos a los componentes necesarios
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudioSource = GetComponent<AudioSource>();
        explosionAudioSource = GetComponent<AudioSource>();
        moneyAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        // Inicializamos la variable Gameover como falsa 
        gameOver = false;
    }

    void Update()
    {
    //Ponemos como condicion que el gameOver sea negativo para que cuando sea positivo se detenga el juego
      if (!gameOver){
        //Hacemos que el player se impulse hacia arriba con el espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            //Añadimos un sonido para cada vez que el player salte
            playerAudioSource.PlayOneShot(boingClip, 1);
        }
        //Establecemos el limite inferior
        if (transform.position.y < downLim)
        {
            Destroy(gameObject);
            gameOver = true;
            cameraAudioSource.volume = 0.01f;
        }
        //Establecemos el limite superior
        if (transform.position.y > upLim)
        {
            transform.position = new Vector3(transform.position.x, upLim,
                transform.position.z);
            //Le damos un poco de impulso hacia abajo al tocar el techo para que el player no se quede pegado arriba
            playerRigidbody.AddForce(Vector3.down * downforce, ForceMode.Impulse);
        }
      }
    }

     private void OnCollisionEnter(Collision otherCollider)
    {
    //Ponemos como condicion que el gameOver sea negativo para que cuando sea positivo se detenga el juego
        if (!gameOver){
            if (otherCollider.gameObject.CompareTag("Money"))
            {   
                //Destruimos el coleccionable al tocarlo
                Destroy(otherCollider.gameObject);
                //Conseguimos un punto
                counter++;
                Vector3 offsetMoney = new Vector3(0, 0, 0);
                //Instanciamos las particulas del coleccionable
                Instantiate(moneyParticleSystem,
                transform.position + offsetMoney,
                moneyParticleSystem.transform.rotation);
                //Indicamos el sonido que reproducirá el objeto
                moneyAudioSource.PlayOneShot(blipClip, 1);
            }

            if (otherCollider.gameObject.CompareTag("Bomb"))
            {
                //Destruimos el obstaculo al tocarlo
                Destroy(otherCollider.gameObject);
                Vector3 offsetExplosion = new Vector3(0, 0, 0);
                //Instanciamos las particulas del obstaculo
                Instantiate(explosionParticleSystem,
                transform.position + offsetExplosion,
                explosionParticleSystem.transform.rotation);
                //Indicamos el sonido que reproducirá el objeto
                explosionAudioSource.PlayOneShot(boomClip, 1);
                //Hacemos verdadero el gameOver y le bajamos bastante el volumen a la musica, todo esto para que se vea que se ha acabado la partida
                gameOver = true;
                cameraAudioSource.volume = 0.01f;
            }
        }
    }
}
