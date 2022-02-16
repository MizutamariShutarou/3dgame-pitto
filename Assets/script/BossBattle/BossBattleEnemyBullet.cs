using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleEnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject m_boss = default;


    // Start is called before the first frame update
    void Start()
    {
        //BossController.Instance.BossDeath += Death;
        Rigidbody rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Destroy(this.gameObject, m_bulletLifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || m_boss != null && BossController.Instance.m_bossHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    //void Death()
    //{
    //    Destroy(gameObject);
    //}
}
