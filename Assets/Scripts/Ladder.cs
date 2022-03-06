using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool m_isInRange;
    private PlayerMovements m_playerMovements;
    public BoxCollider2D m_collider;
    public Text m_interactUI;

    // Start is called before the first frame update
    void Awake()
    {
        m_interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        m_playerMovements = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isInRange && m_playerMovements.m_isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            m_playerMovements.m_isClimbing = false;
            m_collider.isTrigger = false;
            return;
        }

        if (m_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            m_playerMovements.m_isClimbing = true;
            m_collider.isTrigger = true;
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
            m_playerMovements.m_isClimbing = false;
            m_collider.isTrigger = false;
            m_interactUI.enabled = false;
        }
    }
}

