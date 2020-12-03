using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trig : MonoBehaviour {

    public string player;
    void OnTriggerEnter2D (Collider2D col) {
        if (col.tag == player && Character.key == 1) {
            {
                if (SceneManager.GetActiveScene ().buildIndex == level.Levels) {

                    level.Levels++;
                }
                SceneManager.LoadScene (level.Levels);
                Character.key = 0;
            }
        }
    }
}