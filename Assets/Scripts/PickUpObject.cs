using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public AudioClip m_audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.m_instance.PlayClipAt(m_audioClip, transform.position);
            Inventory.m_instance.AddCoin(1);
            CurrentSceneManager.m_instance.m_coinsPickedUpInThisSceneCount++;
            Destroy(gameObject);
        }
    }
}
