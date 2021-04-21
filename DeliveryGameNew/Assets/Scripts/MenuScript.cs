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
    

    public bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*and player isn't dead*/ )
        {
            if (paused)
            {
                resume();
            }
            else
            {
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
        //Disable HUD
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
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
