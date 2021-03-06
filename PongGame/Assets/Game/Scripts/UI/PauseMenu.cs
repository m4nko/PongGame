using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        
    }

    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play(GameSounds.ButtonClick);
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void PauseGame()
    {
        FindObjectOfType<AudioManager>().Play(GameSounds.ButtonClick);
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadSettingsMenuUI()
    {
        FindObjectOfType<AudioManager>().Play(GameSounds.ButtonClick);
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true); 
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<AudioManager>().Play(GameSounds.ButtonClick);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        isGamePaused = false;
    }
}
