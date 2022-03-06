using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    public float m_speed;
    public Transform[] m_waypoints;
    private Transform m_target;
    private int m_destPoint = 0;

    public SpriteRenderer m_spriteRenderer;

    public int m_damage;

    // Start is called before the first frame update
    void Start()
    {
        m_target = m_waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = m_target.position - transform.position;
        transform.Translate(dir.normalized * m_speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, m_target.position) < 0.3f)
        {
            m_destPoint = (m_destPoint + 1) % m_waypoints.Length;
            m_target = m_waypoints[m_destPoint];
            m_spriteRenderer.flipX = !m_spriteRenderer.flipX;
        }
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
