using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int mistakes = 0;
    public ClimberController controller;
    public float cameraPos = -9;

    private void Update()
    {
        if (mistakes == 3)
        {
            GameOver();
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
        GameObject climber = GameObject.Find("Climber");
        climber.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
