using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    [SerializeField] float m_bulletLifeTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        
        Destroy(this.gameObject, m_bulletLifeTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
