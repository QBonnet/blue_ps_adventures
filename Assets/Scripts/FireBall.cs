using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FireBall : MonoBehaviour
{
    public Transform m_target;
    public int m_damage;
    public float m_speed = 5f;
    public float m_rotateSpeed = 200f;

    private Rigidbody2D m_rb;

    private void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)m_target.position - m_rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        m_rb.angularVelocity = -rotateAmount * m_rotateSpeed;
        m_rb.velocity = transform.up * m_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.m_instance.TakeDamage(m_damage);
            Destroy(gameObject);
        }
    }
}
