using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelTwo : MonoBehaviour
{
    public int m_life;
    public int m_damage;
    public bool m_isInvincible = false;
    public float m_invicibilityFlashDelay;
    public float m_invicilityTime;
    public float m_timeBetweenTwoInvoc;
    public bool m_canInvoc = true;
    public SpriteRenderer m_spriteRenderer;
    public BoxCollider2D m_weakSpot;
    public BoxCollider2D m_boxCollider2D;
    public Animator m_animator;
    public GameObject m_signShop;
    public GameObject m_coins;
    public GameObject m_penguinToInvoc;


    public static BossLevelTwo m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("Boss2 > 1");
            return;
        }

        m_instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_canInvoc)
        {
            StartCoroutine(InvocPenguin());
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
            m_weakSpot.enabled = false;
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
        m_weakSpot.enabled = true;
    }

    public IEnumerator InvocPenguin()
    {
        m_canInvoc = false;
        m_animator.SetTrigger("Invoc");
        Instantiate(m_penguinToInvoc);
        yield return new WaitForSeconds(m_timeBetweenTwoInvoc);
        m_canInvoc = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(m_damage);
        }
    }
}
