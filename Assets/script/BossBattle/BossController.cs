using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class BossController : MonoBehaviour
{
    //[SerializeField] float m_withinRange = 0;

    [Header("Status")]
    [SerializeField] public float m_bossHp = 0;
    
    [SerializeField] float m_waitTime = 0;
    [SerializeField] public float m_bossBulletSpeed = 0;

    [Header("FirstMove")]
    [SerializeField] float m_firstDoMoveYPos = 0;
    [SerializeField] float m_firstDoMoveYTime = 0;
    [SerializeField] float m_firstDelayTime = 0;
    [SerializeField] float m_firstDoMoveXPos = 0;
    [SerializeField] float m_firstDoMoveXTime = 0;

    [Header("SecondMove")]
    [SerializeField] float m_secondDoMoveYPos = 0;
    [SerializeField] float m_secondDoMoveYTime = 0;
    [SerializeField] float m_secondDelayTime = 0;
    [SerializeField] float m_secondDoMoveXPos = 0;
    [SerializeField] float m_secondDoMoveXTime = 0;
    //[SerializeField] float m_doMoveXPos = 0;
    //[SerializeField] float m_doMoveXTime = 0;

    [Header("ThirdMove")]
    [SerializeField] float m_thirdDoMoveYPos = 0;
    [SerializeField] float m_thirdDoMoveYTime = 0;
    [SerializeField] float m_thirdDelayTime = 0;
    [SerializeField] float m_thirdDoMoveXPos = 0;
    [SerializeField] float m_thirdDoMoveXTime = 0;
    [SerializeField] float m_thirdXPos = 0;
    //[SerializeField] float m_thirdXTime = 0;

    //[Header("LastMove")]
    //[SerializeField] float m_doMoveY = 0;
    //[SerializeField] float m_doMoveYTime = 0;
    //[SerializeField] float m_thirdDelayTime = 0;

    [SerializeField] GameObject m_bossBullet;
    [SerializeField] GameObject m_player;
    [SerializeField] float m_spChargeValue;

    //bool isOutOfRange = true;

    Rigidbody m_bossRb = default;

    //public delegate void Ondeath();

    //public Ondeath BossDeath;

    public static BossController Instance { get; set; }
    private void Awake()
    {
        Instance = this;
    }
    //Start is called before the first frame update
    void Start()
    {
        m_spChargeValue = GameManager.Instance.m_spValue;
        m_bossBulletSpeed = GameManager.Instance.m_bulletSpeed;
        m_bossRb = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");

        StartCoroutine("BulletShot");

        Sequence MoveSequence = DOTween.Sequence();
        MoveSequence//よりランダム性を追加
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(m_firstDoMoveYPos, m_firstDoMoveYTime))
            .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_firstDoMoveXPos, m_firstDoMoveXTime))
            .SetDelay(m_firstDelayTime)
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(m_secondDoMoveYPos, m_secondDoMoveYTime))
            .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_secondDoMoveXPos, m_secondDoMoveXTime))
            .SetDelay(m_firstDelayTime)
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(m_thirdDoMoveYPos, m_thirdDoMoveYTime))
            .Join(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_thirdDoMoveXPos, m_thirdDoMoveXTime))
            .SetDelay(m_firstDelayTime)
            .SetLink(this.gameObject);

        MoveSequence.SetLoops(-1, LoopType.Yoyo);
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
            Destroy(gameObject);
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
    //public void BossDestroy()
    //{
    //    BossDeath?.Invoke();
    //    Destroy(this.gameObject);
    //}
}

   