using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Deplacements
    public float m_moveSpeed;
    public float m_jumpForce;
    public Rigidbody2D m_rb;
    private Vector3 m_velocity = Vector3.zero;
    private float m_horizontalMovement;
    private float m_smoothTime = 0.05f;

    // Saut
    //public Transform m_groundCheckLeft;
    //public Transform m_groundCheckRight;
    public Transform m_groundCheck;
    public float m_groundCheckRadius;
    public LayerMask m_collisionLayers;
    private bool m_isJumping = false;
    private bool m_isGrounded = true;

    // Animations
    public Animator m_animator;
    public SpriteRenderer m_spriteRenderer;

    // Monter echelle
    [HideInInspector]
    public bool m_isClimbing;
    private float m_verticalMovement;
    public float m_climbSpeed;

    public CapsuleCollider2D m_capsuleCollider;

    // Singleton
    public static PlayerMovements m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("PlayerMovements > 1");
            return;
        }

        m_instance = this;
    }

    void FixedUpdate()
    {
        //m_isGrounded = Physics2D.OverlapArea(m_groundCheckLeft.position, m_groundCheckRight.position);
        m_isGrounded = Physics2D.OverlapCircle(m_groundCheck.position, m_groundCheckRadius, m_collisionLayers);

        m_horizontalMovement = Input.GetAxis("Horizontal") * m_moveSpeed * Time.deltaTime;
        m_verticalMovement = Input.GetAxis("Vertical") * m_climbSpeed * Time.deltaTime;

        Move(m_horizontalMovement, m_verticalMovement);

        Flip(m_rb.velocity.x);

        float characterVelocity = Mathf.Abs(m_rb.velocity.x);
        m_animator.SetFloat("Speed", characterVelocity);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && m_isGrounded && !m_isClimbing)
        {
            m_isJumping = true;
        }
    }

    void Move(float horizontalMovement, float verticalMovement)
    {
        if (!m_isClimbing)
        {
            Vector3 targetVelocity = new Vector2(horizontalMovement, m_rb.velocity.y);
            m_rb.velocity = Vector3.SmoothDamp(m_rb.velocity, targetVelocity, ref m_velocity, m_smoothTime);

            if (m_isJumping)
            {
                m_rb.AddForce(new Vector2(0f, m_jumpForce));
                m_isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocity = new Vector2(0, verticalMovement);
            m_rb.velocity = Vector3.SmoothDamp(m_rb.velocity, targetVelocity, ref m_velocity, m_smoothTime);
        }
    }

    void Flip(float velocity)
    {
        if (velocity > 0.1f)
        {
            m_spriteRenderer.flipX = false;
        }
        else if (velocity < -0.1f)
        {
            m_spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(m_groundCheck.position, m_groundCheckRadius);
    }
}
