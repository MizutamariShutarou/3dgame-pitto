using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BossEnemySpawn : MonoBehaviour
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

        m_Spawned = false;
        enemysNum = 0;
        //BossController.Instance.BossDeath += Death;
    }

    // Update is called once per frame

    void Update()
    {
        var random = Random.Range(0, m_enemys.Length - 1);
        if (enemysNum >= maxEnemysNum)
        {
            return;
        }
        if (m_stage != null && m_stage.transform.position.z < m_spawnStartStagePos && BossController.Instance.m_bossHp > 0)
        {
            m_Spawned = true;
            StartCoroutine("SpawnEnemys");
            AppearEnemys();
        }
        if(m_boss != BossController.Instance.m_bossHp <= 0 || !Player_Model.Instance.IsPlayerMoved)
        {
            StopCoroutine("SpawnEnwmy");
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
        while (m_Spawned)
        {
            yield return new WaitForSeconds(m_spawnTime);
            AppearEnemys();
            if (m_stage.transform.position.z < m_stageEnd) yield break; //Debug.Log("打ち終わり");
        }
    }
    //void Death()//wjfwehfe9wcwえｐｊ０
    //{
    //    Destroy(gameObject);
    //}
}
