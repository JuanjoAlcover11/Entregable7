using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float spinSpeed;
    private PlayerController playerControllerScript;

     void Start()
    {
       playerControllerScript = FindObjectOfType<PlayerController>();
    }
    
    void Update()
    {
    //Ponemos como condicion que el gameOver sea negativo para que cuando sea positivo se detenga el juego
    if (!playerControllerScript.gameOver){
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}
