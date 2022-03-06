using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteFall : MonoBehaviour
{
    public GameObject m_stalactite;
    public float m_timeBetweenFalls;


    private Vector3 m_initVector;
    private Quaternion m_initQuater;
    private bool m_canCreateStalactite = true;

    // Start is called before the first frame update
    void Start()
    {
        m_initVector = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        m_initQuater = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_canCreateStalactite)
        {
            CreateNewStalactite();
        }        
    }

    public void CreateNewStalactite()
    {
        m_canCreateStalactite = false;
        Instantiate(m_stalactite, m_initVector, m_initQuater);
        StartCoroutine(FallsDelay());
    }

    public IEnumerator FallsDelay()
    {
        yield return new WaitForSeconds(m_timeBetweenFalls);
        m_canCreateStalactite = true;
    }
}
