using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] m_enemys = default;
    [SerializeField] GameObject m_stage = default;
    [SerializeField] GameObject m_boss = default;
    [SerializeField] int maxEnemysNum = default;
    private int enemysNum;

    [SerializeField] float m_spawnTime;
    [SerializeField] float m_spawnStartStagePos = 0;
    [SerializeField] float m_stageEnd;
    bool m_Spawned;
    
    // Start is called before the first frame update
    void Start()
    {
        m_stage = GameObject.Find("Stage");
        m_Spawned = false;
        enemysNum = 0;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (enemysNum >= maxEnemysNum)
        {
            return;
        }
        if (m_stage != null && m_stage.transform.position.z < m_spawnStartStagePos)
        {
            m_Spawned = true;
            StartCoroutine("SpawnEnemys");
            AppearEnemys();
        }
        if(PlayerController.Instance.m_playerHp <= 0 || m_stage.transform.position.z < m_stageEnd)
        {
            StopCoroutine("SpawnEnemys");
        }
        
    }

    void AppearEnemys()
    {
        var random = Random.Range(0, m_enemys.Length);
        GameObject.Instantiate(m_enemys[random], transform.position, Quaternion.identity);
        enemysNum++;
    }
    IEnumerator SpawnEnemys()
    {
        while(m_Spawned)
        {
            yield return new WaitForSeconds(m_spawnTime);
            AppearEnemys();
            //if (m_stage.transform.position.z < m_stageEnd) yield break; //Debug.Log("打ち終わり");
        }
    }
}
