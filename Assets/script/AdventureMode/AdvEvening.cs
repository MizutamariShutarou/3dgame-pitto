using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvEvening : MonoBehaviour
{
    [SerializeField] GameObject m_stage = default;
    [SerializeField] float m_stageSpeed = 0f;
    //[SerializeField] float m_startStageRotationPos = 0;
    [SerializeField] float m_goalPos = 0;
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
        if (Player_Model.Instance.IsPlayerMoved)
        {
            m_stageRb.velocity = Vector3.back * m_stageSpeed;
            //if (m_stage.transform.position.z < m_startStageRotationPos)
            //{
            //    m_stageRb.angularVelocity = new Vector3(-0.f, 0, 0);
            //}
        }
        else if (!Player_Model.Instance.IsPlayerMoved)
        {
            m_stageRb.velocity = m_stageRb.transform.position.normalized * 0;
            m_stageRb.angularVelocity = Vector3.zero;
        }
        if (transform.position.z < m_goalPos)
        {
            SceneChange.LoadScene("AdvNight");
        }

        //if (transform.position.z < m_goalPos(-705f))
        //{
        //    //goal
        //}
    }
}
