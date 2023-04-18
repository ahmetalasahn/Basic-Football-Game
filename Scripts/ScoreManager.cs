using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    GameManager manager;
    public int scoreValue;
    public AudioSource coinSound;
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.addScore(scoreValue);
            Destroy(this.gameObject);
            coinSound.Play();
        }    
    }
}
