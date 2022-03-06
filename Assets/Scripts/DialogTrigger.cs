using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_dialog;
    public bool m_isInRange;
    public Text m_interactUI;

    private void Awake()
    {
        m_interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_isInRange = true;
            m_interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_isInRange = false;
            m_interactUI.enabled = false;
            DialogManager.m_instance.EndDialog();
        }
    }

    public void TriggerDialog()
    {
        DialogManager.m_instance.StartDialog(m_dialog);
    }
}
