using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
   
    void Start()
    {
        StopTime();
        GameManager.singleton.PauseButton.gameObject.SetActive(false);
        GameManager.singleton.ResumeButton.gameObject.SetActive(false);
        GameManager.singleton.InGame = false;
    }

   
    public void ResumeGame()
    {
        StartTime();
        GameManager.singleton.InGame = true;
        GameManager.singleton.PauseButton.gameObject.SetActive(true);
        GameManager.singleton.ResumeButton.gameObject.SetActive(false);
        GameManager.singleton.QuitButton.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        StopTime();
        GameManager.singleton.InGame = false;
        GameManager.singleton.PauseButton.gameObject.SetActive(false);
        GameManager.singleton.ResumeButton.gameObject.SetActive(true);
        GameManager.singleton.QuitButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {

        StartTime();
        GameManager.singleton.InGame = true;
        GameManager.singleton.PauseButton.gameObject.gameObject.SetActive(true);
        GameManager.singleton.StartButton.gameObject.SetActive(false);
        GameManager.singleton.QuitButton.gameObject.SetActive(false);
    }


    public void StopTime()
    {
        Time.timeScale = 0f;
    }
    public void StartTime()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
