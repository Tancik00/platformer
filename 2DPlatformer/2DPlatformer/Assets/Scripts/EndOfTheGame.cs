using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfTheGame : MonoBehaviour
{
    public GameObject ep;
    public string player;
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Character.score1=0;
        Character.score2=0;
        Character.score3=0;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == player && Character.key == 1) {
                ep.SetActive(true);
                Character.key = 0;
        }
    }
}
