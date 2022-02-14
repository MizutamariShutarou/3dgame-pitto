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
    [SerializeField] float m_Time;
    
    // Start is called before the first frame update
    void Start()
    {
        enemysNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var random = Random.Range(0, m_enemys.Length);
        if (enemysNum >= maxEnemysNum)
        {
            return;
        }
        if (m_stage.transform.position.z < -120)
        {
            AppearEnemys();
        }
    }

    void AppearEnemys()
    {
        var random = Random.Range(0, m_enemys.Length);
        GameObject.Instantiate(m_enemys[random], transform.position, Quaternion.identity);
        enemysNum++;
    }
}
