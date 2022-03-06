using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstLevel : MonoBehaviour
{
    public int m_life;
    public bool m_isInvincible = false;
    public float m_invicibilityFlashDelay;
    public float m_invicilityTime;
    public SpriteRenderer m_spriteRenderer;
    public BoxCollider2D m_boxCollider2D;
    public PolygonCollider2D m_polygonCollider2D;

    public Animator m_animator;

    public GameObject m_signShop;
    public GameObject m_coins;
    

    public static BossFirstLevel m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("Boss1 > 1");
            return;
        }

        m_instance = this;
        
    }

    private void Update()
    {
        if (PlayerHealth.m_instance.m_isInvincible)
        {
            m_animator.SetBool("isAttacking", true);
        }
        else
        {
            m_animator.SetBool("isAttacking", false);
        }
    }

    public void LoseLife(int life)
    {
        if (!m_isInvincible)
        {
            if (m_life - life <= 0)
            {
                m_animator.SetTrigger("Die");
                m_signShop.SetActive(true);
                m_coins.SetActive(true);
            }
            m_life -= life;
            m_isInvincible = true;
            m_boxCollider2D.enabled = false;
            m_polygonCollider2D.enabled = false;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
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
        m_boxCollider2D.enabled = true;
        m_polygonCollider2D.enabled = true;

    }
}
