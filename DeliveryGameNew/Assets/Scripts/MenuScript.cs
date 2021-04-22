using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject warning;
    public GameObject background;
    public GameObject HUD;
    public GameObject Logo;

    public GameObject GameHandler;


    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (GameHandler.GetComponent<Timer>().timeAmount != 0))
        {
            if (paused)
            {
                SoundManager.PlaySound("UnPauseSound");
                resume();
            }
            else
            {
                SoundManager.PlaySound("PauseSound");
                Pause();
            }
        }
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        
        background.SetActive(true);
        Logo.SetActive(true);
        HUD.SetActive(false);
    }

    public void resume()
    {
        paused = false;
        background.SetActive(false);
        pauseMenu.SetActive(false);
        warning.SetActive(false);

        Logo.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SoundManager.PlaySound("MenuSound");
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SoundManager.PlaySound("MenuSound");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
