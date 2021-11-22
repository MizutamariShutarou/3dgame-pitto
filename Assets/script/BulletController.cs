using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] float m_bulletLifeTime = 10f;
    //[SerializeField] GameObject m_enemy = default;
    //[SerializeField] float m_outoAimRange;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        //m_enemy = GameObject.FindWithTag("Enemy");
        Destroy(this.gameObject, m_bulletLifeTime);
    }
    //private void Update()
    //{
    //    Vector3 v = m_enemy.transform.position - transform.position;
    //    if(v.y < m_outoAimRange)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, m_enemy.transform.position, Time.deltaTime);
    //    }
    //}

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
