using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pp.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pp.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    public void PauseOn()
    {
        pp.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Contin()
    {
        pp.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
