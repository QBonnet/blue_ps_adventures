using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button m_worldButton1;
    public Button m_worldButton2;
    public Button m_worldButton3;
    public Button m_bossButton1;
    public Button m_bossButton2;
    public Button m_bossButton3;



    private void Start()
    {
        m_worldButton2.interactable = false;
        m_worldButton3.interactable = false;
        m_bossButton1.interactable = false;
        m_bossButton2.interactable = false;
        m_bossButton3.interactable = false;

        if (LoadAndSaveData.m_instance.m_levelsVisited.Contains("Level1C"))
        {
            m_worldButton2.interactable = true;
        }
        if (LoadAndSaveData.m_instance.m_levelsVisited.Contains("Level2C"))
        {
            m_worldButton3.interactable = true;
        }
        if (LoadAndSaveData.m_instance.m_levelsVisited.Contains("Level1B"))
        {
            m_bossButton1.interactable = true;
        }
        if (LoadAndSaveData.m_instance.m_levelsVisited.Contains("Level2B"))
        {
            m_bossButton2.interactable = true;
        }
        if (LoadAndSaveData.m_instance.m_levelsVisited.Contains("Level3B"))
        {
            m_bossButton3.interactable = true;
        }

    }

    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
