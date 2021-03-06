using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuScript : MonoBehaviour
{
    public Animator transition;
   

    public float transitionTime;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void Play()
    {
        SoundManager.PlaySound("MenuSound");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Quit()
    {
        SoundManager.PlaySound("MenuSound");
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
