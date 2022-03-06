using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] m_objects;

    public static DontDestroyOnLoadScene m_instance;

    void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("DontDestroyOnLoad > 1");
            return;
        }

        m_instance = this;

        foreach (var element in m_objects)
        {
            DontDestroyOnLoad(element);
        }
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in m_objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }
}
