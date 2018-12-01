using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool paused = false;
    public GameObject pauseMenuUI;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Return()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }
}
