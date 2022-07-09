using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShotBullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float _speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = transform.forward * _speed;
    }
}