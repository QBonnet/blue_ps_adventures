using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{
    public int m_damage;
    public Rigidbody2D m_rb;
    public int m_fX;
    public int m_fY;
    public float m_time = 10;

    private void Start()
    {
        m_rb.AddForce(new Vector2(m_fX, m_fY));
        DestroyDelay();
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

    public IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(m_time);
        Destroy(gameObject);
    }
}
