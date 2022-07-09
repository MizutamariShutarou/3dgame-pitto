using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float m_bulletLifeTime = 10f;
    [SerializeField] GameObject m_boss = default; 
    
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();       
    }
    private void Update()
    {
        Destroy(this.gameObject, m_bulletLifeTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
