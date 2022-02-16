using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject[] m_enemys;
    [SerializeField] GameObject m_stage;
    [SerializeField] int maxEnemysNum;
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
    }

    // Update is called once per frame
    
    void Update()
    {
        var random = Random.Range(0, m_enemys.Length - 1);
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
            if (m_stage.transform.position.z < m_stageEnd) yield break; //Debug.Log("打ち終わり");
        }
    }
}
