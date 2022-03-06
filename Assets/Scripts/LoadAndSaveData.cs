using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAndSaveData : MonoBehaviour
{
    private string m_sceneName;

    public List<string> m_levelsVisited = new List<string>();

    public static LoadAndSaveData m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("LoadSave > 1");
            return;
        }

        m_instance = this;
    }

    private void Start()
    {
        m_sceneName = SceneManager.GetActiveScene().name;
        SaveData();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_sceneName != SceneManager.GetActiveScene().name)
        {
            m_sceneName = SceneManager.GetActiveScene().name;
            SaveData();
        }
    }

    public void SaveData()
    {
        m_levelsVisited.Add(m_sceneName);
        Debug.Log(m_sceneName);
    }
}
