using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string m_sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (m_sceneName == "Credits")
            {
                DontDestroyOnLoadScene.m_instance.RemoveFromDontDestroyOnLoad();
            }
            SceneManager.LoadScene(m_sceneName);

        }
    }
}
