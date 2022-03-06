using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int m_coinsCount;
    public Text m_coinsCountText;

    public int m_redPotCount;
    public Text m_redPotCountText;
    public int m_bluePotCount;
    public Text m_bluePotCountText;
    public int m_greenPotCount;
    public Text m_greenPotCountText;

    public static Inventory m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("Inventory > 1");
            return;
        }
        
        m_instance = this;
    }

    public void AddCoin(int count)
    {
        m_coinsCount += count;
        m_coinsCountText.text = m_coinsCount.ToString();
    }
    public void RemoveCoins(int count)
    {
        m_coinsCount -= count;
        m_coinsCountText.text = m_coinsCount.ToString();
    }

    public void AddRedPot(int count)
    {
        m_redPotCount += count;
        m_redPotCountText.text = m_redPotCount.ToString();
    }
    public void RemoveRedPot(int count)
    {
        m_redPotCount -= count;
        m_redPotCountText.text = m_redPotCount.ToString();
    }

    public void AddBluePot(int count)
    {
        m_bluePotCount += count;
        m_bluePotCountText.text = m_bluePotCount.ToString();
    }
    public void RemoveBluePot(int count)
    {
        m_bluePotCount -= count;
        m_bluePotCountText.text = m_bluePotCount.ToString();
    }

    public void AddGreenPot(int count)
    {
        m_greenPotCount += count;
        m_greenPotCountText.text = m_greenPotCount.ToString();
    }
    public void RemoveGreenPot(int count)
    {
        m_greenPotCount -= count;
        m_greenPotCountText.text = m_greenPotCount.ToString();
    }
}
