using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject m_enemyMuzzle = default;
    List<GameObject> m_enemyList = new List<GameObject>();
    [SerializeField] float m_homingSpeed = 0;
    [SerializeField] float m_distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        m_enemyMuzzle = GameObject.Find("Muzzle");
    }
    private void Update()
    {
        if (m_enemyMuzzle != null)//nullじゃないときにホーミングする
        {
            float dis = Vector3.Distance(this.transform.position, m_enemyMuzzle.transform.position);
            if (dis < m_distance)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, m_enemyMuzzle.transform.position, m_homingSpeed * Time.deltaTime);
            }
        }
        Destroy(this.gameObject, m_bulletLifeTime);
    }
        
    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Muzzle"))
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
