using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletController : MonoBehaviour
{
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject m_enemyMuzzle = default;
    [SerializeField] GameObject[] m_enemys;
    [SerializeField] float m_homingSpeed = 0;
    [SerializeField] float m_distance = 0;
    
    [SerializeField] float m_radius = 5.0f;

    [SerializeField] LayerMask m_enemyLayer = default;

    void Start()
    {
        m_radius = GameManager.Instance.m_homingRange;
        Rigidbody rb = GetComponent<Rigidbody>();
        m_enemyMuzzle = GameObject.Find("Muzzle");
    }
    private void Update()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position,m_radius,m_enemyLayer);
        foreach (var enemys in targets)
        {
            m_enemyMuzzle = enemys.gameObject;
        }
        if (m_enemyMuzzle != null)//nullじゃないときにホーミングする
        {
            float dis = Vector3.Distance(this.transform.position, m_enemyMuzzle.transform.position);
            if (dis < m_distance)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, m_enemyMuzzle.transform.position, m_homingSpeed * Time.deltaTime);
            }
        }
        Destroy(this.gameObject, m_bulletLifeTime);
        if(!PlayerController.Instance.IsPlayerMoved)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Enemy") || m_enemyMuzzle != null && collision.transform.CompareTag("Muzzle"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;//m_homingRangeの可視化
        Gizmos.DrawWireSphere(transform.position, m_distance);
    }

}
