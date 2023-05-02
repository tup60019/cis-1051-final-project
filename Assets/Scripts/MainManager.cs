using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int mistakes = 0;
    public ClimberController controller;
    public float cameraPos = -8.74f;

    private void Update()
    {



        if (mistakes == 10)

        {
            GameOver();
            mistakes = 0;
        }
        if (controller.climberIsAlive == false)
        {
            mistakes = 0;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void GameOver()
    {
        controller.climberIsAlive = false;
        gameOverScreen.SetActive(true);
        StopAllCoroutines();
        GameObject climber = GameObject.FindGameObjectWithTag("Climber");
        climber.GetComponent<BoxCollider2D>().isTrigger = true;
        climber.GetComponent<Rigidbody2D>().gravityScale = 1.0f;


    }
    
}
