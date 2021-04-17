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
        
        //IF player dead 
        //gameover()
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        background.SetActive(true);

        //HUD.SetActive(false);
        //Disable HUD
    }

    public void resume()
    {
        paused = false;
        background.SetActive(false);
        pauseMenu.SetActive(false);
        warning.SetActive(false);
        Time.timeScale = 1;

        //OptionsMenu.SetActive(false);
        //Enable hud
        //HUD.SetActive(true);

    }

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    public void gameOver()
    {
        //get score

        //HUD.SetActive(false);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
