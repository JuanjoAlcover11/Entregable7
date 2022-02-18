using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private Vector3 spawnPosition;
    private float yRange = 14f;
    private float spawnX = -15f;
    private float startTime = 1f;
    private float repeatRate = 2f;
    private float randomY;
    private int randomIndex;
    private PlayerController playerControllerScript;

    void Start()
    {
    //Establecemos la velocidad de aparicion de los objetos
       InvokeRepeating("SpawnObject", startTime, repeatRate);
    //Llamamos al script PlayerController para poder utilizar la variable GameOver
       playerControllerScript = FindObjectOfType<PlayerController>();
    }

     public Vector3 RandomSpawnPosition()
    {
    //Establecemos la posicion en la que apareceran los objetos
     randomY = Random.Range(1, yRange);
     return new Vector3(spawnX, randomY, 0);
    }

    public void SpawnObject()
    {
        //Hacemos que puedan aparecer tanto coleccionables como obstaculos de forma aleatoria
        randomIndex = Random.Range(0, objectPrefabs.Length);
        //Ponemos como condicion que el gameOver sea negativo para que cuando sea positivo se detenga el juego
        if (!playerControllerScript.gameOver){
        //Instanciamos los objetos indicando su posicion y rotacion
        Instantiate(objectPrefabs[randomIndex], RandomSpawnPosition(),
            objectPrefabs[randomIndex].transform.rotation);
        }
    }
}    
