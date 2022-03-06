using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLavaBall : MonoBehaviour
{
    public GameObject m_lavaBall;
    public float m_timeBetweenTwoBalls;
    private Vector3 m_initVector;
    private Quaternion m_initQuater;
    private bool m_canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        m_initVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        m_initQuater = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canSpawn)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        m_canSpawn = false;
        Instantiate(m_lavaBall, m_initVector, m_initQuater);
        StartCoroutine(SpawnsDelay());
    }

    public IEnumerator SpawnsDelay()
    {
        yield return new WaitForSeconds(m_timeBetweenTwoBalls);
        m_canSpawn = true;
    }
}
