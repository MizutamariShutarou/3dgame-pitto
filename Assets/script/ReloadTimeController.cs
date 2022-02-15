using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ReloadTimeController : MonoBehaviour
{
    [SerializeField] Slider m_reloadSlider = default;
    float m_reloadMaxValue = 1f;
    [SerializeField] float m_changeTime;
    public bool m_isReloated;
    [SerializeField] float m_time = 0;
    //public bool IsReloaded
    //{
    //    get
    //    {
    //        return m_isReloated;
    //    }
    //    set
    //    {
    //        m_isReloated = value;
    //    }
    //}

    //public static ReloadTimeController Instance { get; private set; } = default;
    // Start is called before the first frame update
    void Start()
    {
        m_reloadSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Fire2();
    }

    void Fire2()
    {
        if (Input.GetButtonDown("Fire2") && !m_isReloated)
        {
            m_isReloated = true;
            DOTween.To(() => m_reloadSlider.value, x => m_reloadSlider.value = x, m_reloadMaxValue, m_changeTime);
            if(m_isReloated && m_reloadSlider.value == m_reloadMaxValue)
            {
                m_reloadSlider.value = 0;
            }
        }
        m_isReloated = false;
    }

    
}

