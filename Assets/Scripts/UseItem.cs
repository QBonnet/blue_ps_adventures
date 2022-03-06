using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    public AudioClip m_useItemSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && (Inventory.m_instance.m_redPotCount >= 1))
        {
            Inventory.m_instance.RemoveRedPot(1);
            PlayerHealth.m_instance.Heal(30);
            AudioManager.m_instance.PlayClipAt(m_useItemSound, transform.position);
        }
        if (Input.GetKeyDown(KeyCode.X) && (Inventory.m_instance.m_bluePotCount >= 1))
        {
            PlayerHealth.m_instance.InvinciblePot();
            Inventory.m_instance.RemoveBluePot(1);
            AudioManager.m_instance.PlayClipAt(m_useItemSound, transform.position);
        }
        if (Input.GetKeyDown(KeyCode.C) && (Inventory.m_instance.m_greenPotCount >= 1))
        {
            PlayerHealth.m_instance.IncreaseMaxHealth(50);
            Inventory.m_instance.RemoveGreenPot(1);
            AudioManager.m_instance.PlayClipAt(m_useItemSound, transform.position);
        }
    }
}
