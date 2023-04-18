using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 respawnPoint;

    GameManager gameManager;

    [SerializeField] float ballForce = 800f;
    [SerializeField] float movement;
    [SerializeField] float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate() 
    {
        rb.AddForce(0, 0, ballForce * Time.fixedDeltaTime);    

        rb.velocity = new Vector3(movement * speed, rb.velocity.y, rb.velocity.z); 
    
        fallDetector();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.respawnPlayer();
        }    
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("FootballEndTower"))
        {
            gameManager.levelUp();
        }
    }

    void fallDetector()
    {
        if (rb.velocity.y < -2f)
        {
            gameManager.respawnPlayer();
        }
    }
}
