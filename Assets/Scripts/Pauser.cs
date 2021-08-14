using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;

    bool isPaused;

    private void Update()
    {
        PauseUnpause();
    }

    //Pauses the game.
    private void PauseUnpause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }
}
