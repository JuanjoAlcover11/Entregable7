using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour

{  
    private float speed = 7f;
    private float rightLim = 15f;
    private PlayerController playerControllerScript;

     void Start()
    {
    //Llamamos al script PlayerController para poder utilizar la variable GameOver
       playerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
    //Ponemos como condicion que el gameOver sea negativo para que cuando sea positivo se detenga el juego
    if (!playerControllerScript.gameOver)
        {
        //Hacemos que los coleccionables i los obstaculos se desplacen a la derecha
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        //Hacemos que los coleccionables i los obstaculos desaparezcan una vez salen de pantalla
        if (transform.position.x > rightLim)
        {
            Destroy(gameObject);
        }
    }

}
