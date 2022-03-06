using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject m_gameOverUI;

    public static GameOverManager m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("GameOverManager > 1");
            return;
        }

        m_instance = this;
    }

    public void OnPlayerDeath()
    {
        if (CurrentSceneManager.m_instance.m_isPlayerPresentByDefault)
        {
            DontDestroyOnLoadScene.m_instance.RemoveFromDontDestroyOnLoad();
        }

        m_gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.m_instance.Respawn();
        Inventory.m_instance.RemoveCoins(CurrentSceneManager.m_instance.m_coinsPickedUpInThisSceneCount);
        m_gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        DontDestroyOnLoadScene.m_instance.RemoveFromDontDestroyOnLoad();
        SceneManager.LoadScene("MainMenu");
    }
}
