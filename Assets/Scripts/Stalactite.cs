using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public int m_damage;

    private void Start()
    {
        
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioManager.m_instance.PlayClipAt(m_deathMob, transform.position);
            PlayerHealth.m_instance.TakeDamage(m_damage);
            Destroy(gameObject);
        }
    }
}

