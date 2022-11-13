using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject m_boss = default;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
    }
    private void Update()
    {
        Destroy(this.gameObject, m_bulletLifeTime);
        if (m_boss != null && BossController.Instance.m_bossHp <= 0)
        {
            Destroy(gameObject);
        }
        if(!Player_Model.Instance.IsPlayerMoved)
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
    

}