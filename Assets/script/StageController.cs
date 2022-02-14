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
        if(PlayerController.Instance.IsPlayerMoved)
        {
            m_stageRb.velocity = m_stageRb.transform.position.normalized * m_stageSpeed;
        }
        else if(!PlayerController.Instance.IsPlayerMoved)
        {
            m_stageRb.velocity = m_stageRb.transform.position.normalized * 0;
        }
        
        if(transform.position.z < -540)
        {
            m_stageRb.angularVelocity = new Vector3(-0.04f, 0, 0);
        }

        else if(transform.rotation.z > -60)
        {

        }

        //if (transform.rotation.z < -200) isMoved = false;
    }
}
