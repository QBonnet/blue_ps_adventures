using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public GameObject m_player;
    public float m_timeOffset;
    public Vector3 m_positionOffset;
    public Vector3 m_positionOffsetFinalBoss;
    public Camera m_camera;

    private Vector3 velocity;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level3C" )
        {
            transform.position = m_positionOffsetFinalBoss;
            m_camera.orthographicSize = 6;
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, m_player.transform.position + m_positionOffset, ref velocity, m_timeOffset);
        }
    }
}
