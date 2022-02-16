using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleItem : MonoBehaviour
{
    [SerializeField] float m_itemSpeed = 0;
    [SerializeField] float m_healItemLifeTime = 0;
    [SerializeField] GameObject m_boss = default;
    Rigidbody m_rb = default;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        //BossController.Instance.BossDeath += Death;
    }

    void Update()
    {
        m_rb.velocity = Vector3.back * m_itemSpeed;
        if (!PlayerController.Instance.IsPlayerMoved)
        {
            m_itemSpeed = 0;
        }
        Destroy(this.gameObject, m_healItemLifeTime);
        if (m_boss != null && BossController.Instance.m_bossHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    //void Death()//wjfwehfe9wcwえｐｊ０
    //{
    //    Destroy(gameObject);
    //}
}