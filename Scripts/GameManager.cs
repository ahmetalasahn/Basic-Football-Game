using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    float respawnDelay = 2f;
    bool isEnding = false;
    int score;
    public TMP_Text scoreText;
    public GameObject winUI;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void respawnPlayer()
    {
        if (isEnding == false)
        {
            isEnding = true;
            StartCoroutine("respawnCoroutine");   
        }
    }

    public IEnumerator respawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isEnding = false;
    }

    public void addScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = "Atılan Gol: " + score;
    }

    public void levelUp()
    {
        winUI.SetActive(true);
        Invoke("nextLevel", respawnDelay);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
