using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float m_aimSpeed = 0;
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject[] m_enemy = default;
    List<GameObject> m_enemyList = new List<GameObject>();
    
    [SerializeField] float m_outoAimRange;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //m_enemy = GameObject.FindGameObjectsWithTag("Enemy");
        
        Destroy(this.gameObject, m_bulletLifeTime);
    }
    private void Update()
    {
        //GameObject closestEnemy = default;
        //closestEnemy = m_enemyList[0];
        //foreach (var i in m_enemy)
        //{
           //m_enemyList.Add(i);
        //}

        //for (int i = 0; i < m_enemyList.Count; i++)
        //{
            //Vector3 v = m_enemyList[i].transform.position - transform.position;
            //if (v.y < m_outoAimRange)
            //{
                //transform.position = Vector3.MoveTowards(transform.position, m_enemyList[i].transform.position, Time.deltaTime);
            //}
        //}
    }
        
    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            //m_enemyList.Remove(m_enemy[0]);
        }
    }
    
}
