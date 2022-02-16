using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossController : MonoBehaviour
{
    //[SerializeField] float m_withinRange = 0;

    [Header("Status")]
    [SerializeField] float m_bossHp = 0;
    
    [SerializeField] float m_waitTime = 0;
    [SerializeField] public float m_bossBulletSpeed = 0;

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

    [SerializeField] GameObject m_bossBullet;
    [SerializeField] GameObject m_player;
    [SerializeField] float m_spChargeValue;

    //bool isOutOfRange = true;

    Rigidbody m_bossRb = default;
    //Start is called before the first frame update
    void Start()
    {
        m_spChargeValue = GameManager.Instance.m_spValue;
        m_bossRb = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");

        StartCoroutine("BulletShot");

        DOTween.Sequence()//よりランダム性を追加
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(Random.Range(-m_firstDoMoveYPos, m_firstDoMoveYPos), Random.Range(0, m_firstDoMoveYTime)).SetRelative(true))
            .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(Random.Range(-m_firstDoMoveXPos, m_firstDoMoveXPos), Random.Range(0, m_firstDoMoveXTime)).SetDelay(Random.Range(1, m_firstDelayTime))).SetRelative(true)
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(Random.Range(-m_doMoveXPos, m_doMoveXPos), Random.Range(-m_doMoveXTime, m_doMoveXTime)).SetDelay(Random.Range(1, m_secondDelayTime))).SetRelative(true)
            .Append(this.transform.DOMoveY(m_doMoveY, m_doMoveYTime).SetDelay(m_thirdDelayTime).SetLink(this.gameObject));
    }

    //Update is called once per frame
    void Update()
    {
        if (m_player != null)//m_playerがnullじゃなければplayerの報を向く
        {
            transform.LookAt(m_player.transform);
        }
        if (m_bossHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulletShot()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_waitTime);
            Rigidbody obj = Instantiate(m_bossBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_bossBulletSpeed;
            if (m_bossHp <= 0) yield break; //打ち終わり
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            m_bossHp --;
        }
    }
}

   