using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy2Controller : MonoBehaviour
{   
    [Header("Status")]
    [SerializeField] float m_enemySpeed = 0f;
    [SerializeField] float m_waitTime = 0;
    [SerializeField] float m_destroyPos = 0;
    [SerializeField] float m_breakPos;
    [SerializeField] float m_spChargeValue;
    public float m_enemyBulletSpeed = 40;

    [Header("FirstMove")]
    [SerializeField] float m_firstDoMoveYPos = 0;
    [SerializeField] float m_firstDoMoveYTime = 0;
    [SerializeField] float m_firstDelayTime = 0;
    [SerializeField] float m_firstDoMoveXPos = 0;
    [SerializeField] float m_firstDoMoveXTime = 0;
    [Header("SecondMove")]
    [SerializeField] float m_doMoveXPos = 0;
    [SerializeField] float m_doMoveXTime = 0;
    [SerializeField] float m_secondDelayTime = 0;

    [Header("LastMove")]
    [SerializeField] float m_doMoveY = 0;
    [SerializeField] float m_doMoveYTime = 0;
    [SerializeField] float m_thirdDelayTime = 0;

    [SerializeField] GameObject m_enemyBullet = default;
    [SerializeField] GameObject m_player = default;
    [SerializeField] GameObject m_boss = default;
    [SerializeField] GameObject m_stage = default;
    [SerializeField] float m_goalPos = 0;
    
    Rigidbody m_enemyRb = default;
    void Start()
    { 
        m_spChargeValue = GameManager.Instance.m_spValue;
        m_enemyBulletSpeed = GameManager.Instance.m_bulletSpeed;
        m_enemyRb = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");
        m_stage = GameObject.Find("Stage");
        
        StartCoroutine("BulletShot");

        //DOTween.Sequence()
        //    .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(m_firstDoMoveYPos, m_firstDoMoveYTime)).SetRelative(true)
        //    .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_firstDoMoveXPos,m_firstDoMoveXTime).SetDelay(m_firstDelayTime)).SetRelative(true)
        //    .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_doMoveXPos, m_doMoveXTime).SetDelay(m_secondDelayTime)).SetRelative(true)
        //    .Append(this.transform.DOMoveY(m_doMoveY, m_doMoveYTime).SetDelay(m_thirdDelayTime).SetLink(this.gameObject));

        DOTween.Sequence()//よりランダム性を追加
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(Random.Range(-m_firstDoMoveYPos,m_firstDoMoveYPos), Random.Range(0, m_firstDoMoveYTime)).SetRelative(true))
            .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(Random.Range(-m_firstDoMoveXPos, m_firstDoMoveXPos), Random.Range(0, m_firstDoMoveXTime)).SetDelay(Random.Range(1, m_firstDelayTime))).SetRelative(true)
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(Random.Range(-m_doMoveXPos, m_doMoveXPos), Random.Range(-m_doMoveXTime, m_doMoveXTime)).SetDelay(Random.Range(1, m_secondDelayTime))).SetRelative(true)
            .Append(this.transform.DOMoveY(m_doMoveY, m_doMoveYTime).SetDelay(m_thirdDelayTime).SetLink(this.gameObject));
    }
    void Update()
    {
        m_enemyRb.velocity = Vector3.back * m_enemySpeed;

        if (m_player != null)//m_playerがnullじゃなければplayerを向く
        {
            transform.LookAt(m_player.transform);
        }

        if (transform.position.y >= m_destroyPos)
        {
            EnemyDestroy();
        }
        
        if(!PlayerController.Instance.IsPlayerMoved)
        {
            StopCoroutine("BulletShot");
            m_enemyRb.velocity = Vector3.back * 0;
        }

        if (m_stage.transform.position.z <= m_goalPos)
        {
            EnemyDestroy();
        }
    }

    IEnumerator BulletShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_waitTime);
            Rigidbody obj = Instantiate(m_enemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_enemyBulletSpeed;
            if (transform.position.y > m_breakPos) yield break; //打ち終わり
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            SpecialGage.Instance.ChangeValue(m_spChargeValue);
            EnemyDestroy();
        }
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }


}