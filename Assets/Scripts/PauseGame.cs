using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public UnityEngine.GameObject pauseScreen;

    public void PauseButon()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
