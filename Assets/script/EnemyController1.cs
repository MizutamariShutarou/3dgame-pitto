using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyController1 : MonoBehaviour
{
    [SerializeField] float m_enemySpeed = 5f;
    //[SerializeField] float m_enemyHp = 5f;
    [SerializeField] float m_move = 0;
    [SerializeField] float m_moveTime = 0;
    public GameObject m_enemyBullet;
    public GameObject m_player;
    public float m_enemyBulletSpeed = 0;
    //[SerializeField] GameObject m_enemyMuzzle;
    Rigidbody m_enemyRb = default;
    //Start is called before the first frame update
    void Start()
    {
        m_enemyRb = GetComponent<Rigidbody>();
        //transform.LookAt(m_player.transform);
        m_player = GameObject.Find("Player");
        StartCoroutine("BulletShot");
        this.transform.DOMoveX(m_move, m_moveTime);
    }

    //Update is called once per frame
    void Update()
    {
        m_enemyRb.velocity = Vector3.back * m_enemySpeed;
        transform.LookAt(m_player.transform);
    }

    IEnumerator BulletShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            //Rigidbody obj = Instantiate(m_enemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //obj.velocity = transform.forward.normalized * m_enemyBulletSpeed;
            Rigidbody obj = Instantiate(m_enemyBullet,transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_enemyBulletSpeed;
            
        }
    }


    //public override void Activate()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
