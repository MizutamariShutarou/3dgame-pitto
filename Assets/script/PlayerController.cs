using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerController : MonoBehaviour
{
    Rigidbody m_rb = default;
    [SerializeField] Transform m_image;
    [SerializeField] Renderer m_playerRenderer;
    [SerializeField] Renderer m_muzzleRenderer;
    [SerializeField] GameObject[] m_enemys = default;
    //[SerializeField] GameObject m_enemyBullet = default;
    [SerializeField] GameObject effectPrefab;
    [SerializeField] GameObject[] m_bulletIcon = default;
    [SerializeField] GameObject m_healItem;
    [SerializeField] ItemSpawnManager m_itemSpawnController = default;
    [SerializeField] float m_waitTime = 0;
    [SerializeField] float m_reloadChangeValue = 0;
    
    bool m_isReloaded;
    
    [Header("Status")]
    [SerializeField] float m_playerSpeed = 10f;
    [SerializeField] public int m_playerHp = 0;
    //[SerializeField] bool isOutRange = true;//playerの移動範囲の制御
    bool m_isPlayerMoved = true;
    
    [Header("BulletStatus")]
    [SerializeField] GameObject m_bullet = default;
    [SerializeField] float m_bulletSpeed;
    [SerializeField] GameObject m_muzzle = default;
    //[SerializeField] GameObject m_crosshair = default;
    [SerializeField] int m_maxBulletCount = 0;
    [SerializeField] int m_bulletCount = 10;
    
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
        m_rb = GetComponent<Rigidbody>();
        //isOutRange = true;
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

        if (m_playerHp <= 0)//死んだとき色かわって回転しながら落ちていく
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
    public void Fire1()
    {
        if (Input.GetButtonDown("Fire1") && m_bulletCount > 0 && !m_isReloaded)//!m_isReloadedの追加でリロード時のラグ発生中に撃てないようにする
        {
            Rigidbody obj = Instantiate(m_bullet, m_muzzle.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_bulletSpeed;
            m_bulletCount--;
            UpdateBulletIcon();
        }
    }
    public void Fire2()//リロード
    {
        if (Input.GetButtonDown("Fire2") && !m_isReloaded && m_bulletCount < m_maxBulletCount)
        {
            StartCoroutine("StartReload");//ラグの開始
            ReloadTimeController.Instance.StartReloadTime();
        }
    }
    void SpecialAttack()//もしm_fulledSp = trueなら必殺技がうてる。
    {
        if (Input.GetKeyDown("space"))
        {
            if (SpecialGage.Instance.IsFulledSp)//100になったらtrueになって必殺技が打てる(撃った後はfalseに)
            {
                SpecialGage.Instance.ResetValue();
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
    IEnumerator StartReload()//リロード時にラグ(次撃てるようになるまでの待機時間)を設ける
    {
        m_isReloaded = true;
        while(m_isReloaded)
        {
            yield return new WaitForSeconds(m_waitTime);
            m_bulletCount = m_maxBulletCount;
            ResetBulletIcon();
            m_isReloaded = false;
            if (m_bulletCount == m_maxBulletCount) yield break;
        }

    }

    private void OnTriggerEnter(Collider other)//HP制
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            HPController.Instance.ChangeValue(1f);
            m_playerHp--;
        }
        else if (other.gameObject.CompareTag("Heal"))
        {
            if (HPController.Instance.HpValue < 10)
            {
                m_playerHp++;
                HPController.Instance.ChangeValue(-1f);
            }
        }
    }
    void UpdateBulletIcon()//弾をうつと段数が減っていく
    {
        for (int i = 0; i < m_bulletIcon.Length; i++)
        {
            if (m_bulletCount <= i)
            {
                m_bulletIcon[i].SetActive(false);
            }
            else
            {
                m_bulletIcon[i].SetActive(true);
            }
        }
    }
    void ResetBulletIcon()//リロード時に段数表示を戻す
    {
        for(int i = 0; i < m_bulletIcon.Length; i++)
        {
            m_bulletIcon[i].SetActive(true);
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
