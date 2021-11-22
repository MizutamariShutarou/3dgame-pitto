using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] float m_stageSpeed =50f;
    Rigidbody m_stageRb = default;
    // Start is called before the first frame update
    void Start()
    {
        m_stageRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_stageRb.velocity = m_stageRb.transform.position.normalized * m_stageSpeed;
    }
}
