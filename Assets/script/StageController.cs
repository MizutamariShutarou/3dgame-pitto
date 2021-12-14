using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] float m_stageSpeed =0f;
    Rigidbody m_stageRb = default;

    bool isMoved = true;
    // Start is called before the first frame update
    void Start()
    {
        isMoved = true;
        m_stageRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_stageRb.velocity = m_stageRb.transform.position.normalized * m_stageSpeed;
        if(transform.position.z < -540)
        {
            for (float i = 0; i <= 1.0; i += 0.01f)
            {
                m_stageRb.angularVelocity = new Vector3(i,0,0);
            }
        }

        else if(transform.rotation.z > -60)
        {

        }

        //if (transform.rotation.z < -200) isMoved = false;
    }
}
