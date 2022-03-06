using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Text m_interactUI;

    private bool m_isInRange;
    // Start is called before the first frame update
    void Awake()
    {
        m_interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();     
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            m_interactUI.enabled = false;
            SceneManager.LoadScene("SelectLevelScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_interactUI.enabled = true;
            m_isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_isInRange = false;
            m_interactUI.enabled = false;
        }
    }
}
