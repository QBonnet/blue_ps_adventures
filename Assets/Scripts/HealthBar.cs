using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider m_slider;
    public Text m_numberHP;

    public void SetMaxHealth(int health)
    {
        m_slider.maxValue = health;
        m_slider.value = health;
        m_numberHP.text = health.ToString();
    }

    public void SetHealth(int health)
    {
        m_slider.value = health;
        m_numberHP.text = health.ToString();
    }
}
