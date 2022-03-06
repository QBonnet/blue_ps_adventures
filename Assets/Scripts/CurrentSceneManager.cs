using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public bool m_isPlayerPresentByDefault = false;
    public int m_coinsPickedUpInThisSceneCount;

    public static CurrentSceneManager m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("CurrentSceneManager > 1");
            return;
        }

        m_instance = this;
    }
}
