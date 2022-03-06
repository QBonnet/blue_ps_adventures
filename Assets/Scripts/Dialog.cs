using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class Dialog
{
    public string m_name;
    [TextArea(3, 10)] public string[] m_sentences;
}
