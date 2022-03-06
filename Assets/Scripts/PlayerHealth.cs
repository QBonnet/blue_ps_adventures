using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int m_maxHealth = 100;
    public int m_currentHealth;

    public HealthBar m_healthBar;

    public bool m_isInvincible = false;
    public float m_invicibilityFlashDelay;
    public float m_invincibleTimePotion;
    public float m_invicilityTime;
    public SpriteRenderer m_spriteRenderer;

    public AudioClip m_hitSound;

    public static PlayerHealth m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("PlayerHealth > 1");
            return;
        }

        m_instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_currentHealth = m_maxHealth;
        m_healthBar.SetMaxHealth(m_maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseMaxHealth(int healthSupp)
    {
        m_maxHealth += healthSupp;
        m_healthBar.SetMaxHealth(m_maxHealth);
        m_currentHealth += healthSupp;
        m_healthBar.SetHealth(m_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!m_isInvincible)
        {
            m_currentHealth -= damage;
            AudioManager.m_instance.PlayClipAt(m_hitSound, transform.position);

            if (m_currentHealth <= 0)
            {
                m_currentHealth = 0;
                Die();
            }
            else
            {
                m_isInvincible = true;
                StartCoroutine(InvincibilityFlash());
                StartCoroutine(HandleInvicibilityDelay(m_invicilityTime));
            }

            m_healthBar.SetHealth(m_currentHealth);
        }     
    }

    public void Die()
    {
        PlayerMovements.m_instance.enabled = false;
        PlayerMovements.m_instance.m_animator.SetTrigger("Die");
        PlayerMovements.m_instance.m_rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMovements.m_instance.m_rb.velocity = Vector3.zero;
        PlayerMovements.m_instance.m_capsuleCollider.enabled = false;
        GameOverManager.m_instance.OnPlayerDeath();
    }

    public void Respawn()
    {
        PlayerMovements.m_instance.enabled = true;
        PlayerMovements.m_instance.m_animator.SetTrigger("Respawn");
        PlayerMovements.m_instance.m_rb.bodyType = RigidbodyType2D.Dynamic;
        PlayerMovements.m_instance.m_capsuleCollider.enabled = true;
        m_currentHealth = m_maxHealth;
        m_healthBar.SetHealth(m_currentHealth);
    }

    public void InvinciblePot()
    {
        m_isInvincible = true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvicibilityDelay(m_invincibleTimePotion));
    }

    public void Heal(int healAmount)
    {
        if (m_currentHealth + healAmount > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }
        else
        {
            m_currentHealth += healAmount;
        }
        m_healthBar.SetHealth(m_currentHealth);
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

    public IEnumerator HandleInvicibilityDelay(float time)
    {
        yield return new WaitForSeconds(time);
        m_isInvincible = false;
    }
}
