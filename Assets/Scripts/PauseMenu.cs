using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool m_gameIsPaused = false;
    public GameObject m_pauseMenuUI;
    public GameObject m_settingsWindow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovements.m_instance.enabled = false;
        m_pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        m_gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovements.m_instance.enabled = true;
        m_pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        m_gameIsPaused = false;
    }
    public void LoadMainMenu()
    {
        DontDestroyOnLoadScene.m_instance.RemoveFromDontDestroyOnLoad();
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettingsWindow()
    {
        m_settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        m_settingsWindow.SetActive(false);
    }
}
