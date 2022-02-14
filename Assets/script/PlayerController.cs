using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    Rigidbody m_rb = default;
    [SerializeField] Transform m_image;
    [SerializeField] Renderer m_playerRenderer;
    [SerializeField] Renderer m_muzzleRenderer;
    [SerializeField] GameObject[] m_enemys = default;
    [SerializeField] GameObject effectPrefab;
    [Header("Status")]
    [SerializeField] float m_playerSpeed = 10f;
    [SerializeField] int m_playerHp = 0;
    [SerializeField] bool isOutRange = true;//playerの移動範囲の制御
    bool m_isPlayerMoved = true;
    
    [Header("BulletStatus")]
    [SerializeField] GameObject m_bullet = default;
    [SerializeField] float m_bulletSpeed;
    [SerializeField] GameObject m_muzzle = default;
    //[SerializeField] GameObject m_crosshair = default;
    [SerializeField] int m_maxBulletCount = 0;
    int m_bulletCount = 10;
    
    public bool IsPlayerMoved
    {
        get
        {
            return m_isPlayerMoved;
        }
        set
        {
            m_isPlayerMoved = value;
        }
    }

    public static PlayerController Instance { get; private set; } = default;
    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //　課題　具体的な数字→メンバー変数で作り直してシステムを組み立てる
        m_rb = GetComponent<Rigidbody>();
        
        isOutRange = true;
        m_isPlayerMoved = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isPlayerMoved)
        {
            Move();
            Fire1();
            Fire2();
            SpecialAttack();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(ray.direction);
        }

        if (m_playerHp <= 0)//死んだとき
        {
            m_isPlayerMoved = false;
            m_playerRenderer.material.color = Color.red;
            m_muzzleRenderer.material.color = Color.red;
            m_rb.transform.Rotate(new Vector3(0, 2f, 0));
            m_rb.useGravity = true;
        }

        if(this.transform.position.y < -10)
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
    void SpecialAttack()//もしm_fulledSp = trueなら必殺技がうてる。
    {
        if (Input.GetKeyDown("space"))
        {
            SpecialGage.Instance.ResetValue();
            if (SpecialGage.Instance.IsFulledSp)//100になったらtrueになって必殺技が打てる(撃った後はfalseに)
            {
                m_enemys = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject e in m_enemys)
                {
                    Destroy(e);
                    
                    //GameObject effect = Instantiate(effectPrefab, e.transform.position, Quaternion.identity);
                    //Destroy(effect, 0.5f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)//HP制
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            HPController.Instance.ChangeValue(1f);
            m_playerHp--;
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }



}
