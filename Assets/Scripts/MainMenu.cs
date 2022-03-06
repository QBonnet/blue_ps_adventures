using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string m_levelToLoad;
    public GameObject m_settingsWindow;

    public void PlayButton()
    {
        SceneManager.LoadScene(m_levelToLoad);
    }

    public void SettingsButton()
    {
        m_settingsWindow.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        m_settingsWindow.SetActive(false);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
