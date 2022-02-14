using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float jumpforce = 20f;
    public float gravityModifier = 1;
    private float upLim = 14f;
    public bool gameOver;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
        if (transform.position.y > upLim)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            Debug.Log("GAME OVER");
        }
    }
}
