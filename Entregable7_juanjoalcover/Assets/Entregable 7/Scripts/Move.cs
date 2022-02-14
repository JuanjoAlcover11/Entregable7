using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
        public float speed = 10f;

        private Vector3 startPosition;
        private float repeatWidth;

    private PlayerController playerControllerScript;

        void Start()
        {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

            startPosition = transform.position;
            repeatWidth = GetComponent<BoxCollider>().size.x / 2f;
        }

        // Update is called once per frame
        void Update()
        {
            if (!playerControllerScript.gameOver)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

           if (transform.position.x < startPosition.x - repeatWidth)
            {
                transform.position = startPosition;
            }
    }
}
