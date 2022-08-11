using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ResumeButton;
    public GameObject HomeButton;
    public GameObject Paused;
    public static PauseMenu instance;

    void Awake()
    {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
    }
    
    public void Pause()
    {
        ResumeButton.SetActive(true);
        HomeButton.SetActive(true);
        Paused.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        ResumeButton.SetActive(false);
        HomeButton.SetActive(false);
        Paused.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}
