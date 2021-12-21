using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_rb = default;
    [Header("Status")]
    [SerializeField] float m_playerSpeed = 10f;
    [SerializeField] int m_playerHp = 0;
    [SerializeField] bool isOutRange = true;//playerの移動範囲の制御
    [Header("BulletStatus")]
    [SerializeField] GameObject m_bullet = default;
    [SerializeField] float m_bulletSpeed;
    [SerializeField] GameObject m_muzzle = default;
    //[SerializeField] GameObject m_crosshair = default;
    [SerializeField] int m_maxBulletCount = 0;
    int m_bulletCount = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        //　課題　具体的な数字→メンバー変数で作り直してシステムを組み立てる
        m_rb = GetComponent<Rigidbody>();
        int hpCounts = m_playerHp;
        isOutRange = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire1();
        Fire2();

        if(m_playerHp == 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 vec = new Vector3(h, v, 0);
        m_rb.velocity = vec.normalized * m_playerSpeed;

        
    }
    void Fire1()
    {
        if (Input.GetButtonDown("Fire1") && m_bulletCount > 0)
        {
            Rigidbody obj = Instantiate(m_bullet, m_muzzle.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_bulletSpeed;
            m_bulletCount--;
        }
    }
    void Fire2()//リロード
    {
        if (Input.GetButtonDown("Fire2"))
        {
            m_bulletCount = m_maxBulletCount;
        }
    }

    private void OnTriggerEnter(Collider other)//HP制にした
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            m_playerHp--;
            Debug.Log(m_playerHp);
        }
    }

}
