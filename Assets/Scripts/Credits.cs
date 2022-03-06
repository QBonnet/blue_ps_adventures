using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public AudioClip m_audioClip;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        StartCoroutine(TimerCredits());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

    public IEnumerator TimerCredits()
    {
        yield return new WaitForSeconds(m_audioClip.length);
        LoadMainMenu();

    }
}
