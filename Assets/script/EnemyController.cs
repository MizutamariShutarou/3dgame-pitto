using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyController : MonoBehaviour
{
    [SerializeField] float m_withinRange = 0;
    [Header("Status")]
    [SerializeField] float m_enemySpeed = 0f;
    [SerializeField] float m_waitTime = 0;
    [SerializeField] float m_destroyPos = 0;
    [SerializeField] float m_breakPos;
    public float m_enemyBulletSpeed = 0;

    [Header("FirstMove")]
    [SerializeField] float m_firstDoMoveYPos = 0;
    [SerializeField] float m_firstDoMoveYTime = 0;
    [SerializeField] float m_firstDelayTime = 0;
    
    [Header("SecondMove")]
    [SerializeField] float m_doMoveXPos = 0;
    [SerializeField] float m_doMoveXTime = 0;
    [SerializeField] float m_secondDelayTime = 0;

    [Header("LastMove")]
    [SerializeField] float m_doMoveY = 0;
    [SerializeField] float m_doMoveYTime = 0;
    [SerializeField] float m_thirdDelayTime = 0;
    
    public GameObject m_enemyBullet;
    public GameObject m_player;
    
    bool isOutOfRange = true;
    
    Rigidbody m_enemyRb = default;
    //Start is called before the first frame update
    void Start()
    {
        isOutOfRange = false;
        m_enemyRb = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");
        
        StartCoroutine("BulletShot");

        DOTween.Sequence()
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveY(m_firstDoMoveYPos, m_firstDoMoveYTime).SetDelay(m_firstDelayTime)).SetRelative(true)
            .Append(this.transform.gameObject.GetComponent<Rigidbody>().DOMoveX(m_doMoveXPos, m_doMoveXTime).SetDelay(m_secondDelayTime)).SetRelative(true)
            .Append(this.transform.DOMoveY(m_doMoveY, m_doMoveYTime).SetDelay(m_thirdDelayTime).SetLink(this.gameObject));

        //DOTween.To(() => )
    }

    //Update is called once per frame
    void Update()
    {
        if (transform.position.x > m_withinRange) isOutOfRange = true;
        else isOutOfRange = false;

        m_enemyRb.velocity = Vector3.back * m_enemySpeed;
        transform.LookAt(m_player.transform);
        if (transform.position.y >= m_destroyPos) Destroy(this.gameObject);
    }

    IEnumerator BulletShot()
    {
        while (true)
        {
            //Debug.Log("コルーチンスタート"); //　課題　画面内に敵オブジェクトが現れたらコルーチン開始にしたい
            yield return new WaitForSeconds(m_waitTime);
            Rigidbody obj = Instantiate(m_enemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_enemyBulletSpeed;
            if (transform.position.y > m_breakPos) yield break; //Debug.Log("打ち終わり");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //SpecialGage sp = GameObject.FindObjectOfType<SpecialGage>();　//上手く動かない
            SpecialGage.Instance.ChangeValue(10f);
            //sp.ChangeValue(10f);
            Destroy(this.gameObject);
        }
    }
}