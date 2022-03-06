using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text m_nameText;
    public Text m_dialogText;
    public Animator m_animator;

    private Queue<string> m_sentences;
    
    public static DialogManager m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("Dialog Manager > 1");
            return;
        }

        m_instance = this;

        m_sentences = new Queue<string>();
    }

    public void StartDialog(Dialog dialog)
    {
        m_animator.SetBool("isOpen", true);
        m_nameText.text = dialog.m_name;
        m_sentences.Clear();

        foreach (string sentence in dialog.m_sentences)
        {
            m_sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (m_sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = m_sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WriteSentence(sentence));
    }

    IEnumerator WriteSentence(string sentence)
    {
        m_dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            m_dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        m_animator.SetBool("isOpen", false);
    }
}
