using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    [SerializeField] float m_enemySpeed = 8f;
    //[SerializeField] float m_enemyHp = 5f;

    Rigidbody m_enemyRb = default;
    //Start is called before the first frame update
    void Start()
    {
        m_enemyRb = GetComponent<Rigidbody>();
    }

    //Update is called once per frame
    void Update()
    {
        m_enemyRb.velocity = Vector3.back * m_enemySpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
