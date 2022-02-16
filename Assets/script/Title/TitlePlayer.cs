using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class TitlePlayer : MonoBehaviour
{
    Rigidbody m_rb = default;
    [SerializeField] GameObject m_bullet = default;
    [SerializeField] GameObject m_muzzle = default;
    [SerializeField] float m_bulletSpeed = 0;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire1();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);
    }

    public void Fire1()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Rigidbody obj = Instantiate(m_bullet, m_muzzle.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            obj.velocity = transform.rotation * Vector3.forward * m_bulletSpeed;
        }
    }
}
