using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScreen : MonoBehaviour
{
    public GameObject container;
    public AudioSource gameOverSound;
    public GameObject pauseButton;
    public void Setup()
    {
        pauseButton.SetActive(false);
        container.SetActive(true);
        Time.timeScale = 0;
        gameOverSound.PlayDelayed(0.5f);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
        pauseButton.SetActive(true);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
