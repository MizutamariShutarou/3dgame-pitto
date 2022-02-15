﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItemController : MonoBehaviour
{
    [SerializeField] float m_itemSpeed = 0;
    [SerializeField] float m_healItemLifeTime = 0;
    
    Rigidbody m_rb = default;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_rb.velocity = Vector3.back * m_itemSpeed;
        if(!PlayerController.Instance.IsPlayerMoved)
        {
            m_itemSpeed = 0;
        }
        Destroy(this.gameObject, m_healItemLifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
