using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject m_objectToDestroy;
    public AudioClip m_deathMob;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !gameObject.CompareTag("Boss1") && !gameObject.CompareTag("Boss2") && !gameObject.CompareTag("Boss3"))
        {
            AudioManager.m_instance.PlayClipAt(m_deathMob, transform.position);
            Destroy(m_objectToDestroy);
        }
        else if (collision.CompareTag("Player") && gameObject.CompareTag("Boss1"))
        {
            AudioManager.m_instance.PlayClipAt(m_deathMob, transform.position);
            BossFirstLevel.m_instance.LoseLife(1);
            if (BossFirstLevel.m_instance.m_life <= 0)
            {
                Destroy(m_objectToDestroy);
            }
        }
        else if (collision.CompareTag("Player") && gameObject.CompareTag("Boss2"))
        {
            AudioManager.m_instance.PlayClipAt(m_deathMob, transform.position);
            BossLevelTwo.m_instance.LoseLife(1);
            if (BossLevelTwo.m_instance.m_life <= 0)
            {
                Destroy(m_objectToDestroy);
            }
        }
        else if (collision.CompareTag("Player") && gameObject.CompareTag("Boss3"))
        {
            AudioManager.m_instance.PlayClipAt(m_deathMob, transform.position);
            FinalBoss.m_instance.LoseLife(1);
            if (FinalBoss.m_instance.m_life <= 0)
            {
                Destroy(m_objectToDestroy);
            }
        }
    }
}
