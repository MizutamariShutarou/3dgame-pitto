using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleItemSpawn : MonoBehaviour
{
    [SerializeField] GameObject m_itemPrefab;
    //[SerializeField] GameObject m_player;
    //[SerializeField] int m_healValue;
    [SerializeField] float m_minTime = 2f;
    [SerializeField] float m_maxTime = 5f;
    [SerializeField] float m_xMinPosition = -10f;
    [SerializeField] float m_xMaxPosition = 10f;
    [SerializeField] float m_yMinPosition = 0f;
    [SerializeField] float m_yMaxPosition = 10f;
    [SerializeField] float m_zMinPosition = 10f;
    [SerializeField] float m_zMaxPosition = 20f;
    [SerializeField] float m_interval;
    [SerializeField] float m_time = 0f;
    [SerializeField] GameObject m_stage = default;
    [SerializeField] float m_spawnStartStagePos = 0;
    [SerializeField] GameObject m_boss = default;

    void Start()
    {
        m_interval = GetRandomTime();
        //BossController.Instance.BossDeath += Death;

    }

    void Update()
    {
        m_time += Time.deltaTime;

        if (m_stage != null && m_stage.transform.position.z <= m_spawnStartStagePos)
        {
            if (m_time > m_interval)
            {
                GameObject item = Instantiate(m_itemPrefab);
                item.transform.position = GetRandomPosition();
                m_time = 0f;
                m_interval = GetRandomTime();
            }
        }
        if (m_boss != null && BossController.Instance.m_bossHp <= 0)
        {
            Destroy(gameObject);
        }

    }
    private float GetRandomTime()
    {
        return Random.Range(m_minTime, m_maxTime);
    }
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(m_xMinPosition, m_xMaxPosition);
        float y = Random.Range(m_yMinPosition, m_yMaxPosition);
        float z = Random.Range(m_zMinPosition, m_zMaxPosition);

        return new Vector3(x, y, z);
    }
    //void Death()//wjfwehfe9wcwえｐｊ０
    //{
    //    Destroy(gameObject);
    //}
}