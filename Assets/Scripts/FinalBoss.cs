using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public int m_life;
    public bool m_canShoot = true;
    public Animator m_animator;
    public float m_timeBetweenTwoShoot;
    public GameObject m_fireBall;
    public bool m_isInvincible = false;
    public SpriteRenderer m_spriteRenderer;
    public BoxCollider2D m_weakSpot;
    public float m_invicibilityFlashDelay;
    public float m_invicilityTime;

    public GameObject m_sign;

    public static FinalBoss m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("Boss3 > 1");
            return;
        }

        m_instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public void LoseLife(int life)
    {
        if (!m_isInvincible)
        {
            if (m_life - life <= 0)
            {
                //m_animator.SetTrigger("Die");
                m_sign.SetActive(true);
                
            }
            m_life -= life;
            m_isInvincible = true;
            m_weakSpot.enabled = false;
            
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public IEnumerator Shoot()
    {
        m_canShoot = false;
        Instantiate(m_fireBall);
        yield return new WaitForSeconds(m_timeBetweenTwoShoot);
        m_canShoot = true;
    }

    public IEnumerator InvincibilityFlash()
    {
        while (m_isInvincible)
        {
            m_spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(m_invicibilityFlashDelay);
            m_spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(m_invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(m_invicilityTime);
        m_isInvincible = false;
        m_weakSpot.enabled = true;
    }
}
