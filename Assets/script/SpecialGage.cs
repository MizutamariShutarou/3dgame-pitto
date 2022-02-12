using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpecialGage : MonoBehaviour
{
    [SerializeField] public Slider m_spSlider = default;
    [SerializeField] GameObject[] m_enemys;
    //[SerializeField] int m_maxSpSlider = 100; 
    int m_reset = 0;
    [SerializeField] float m_changeTime;
    float m_time;
    public bool m_fulledSp = false;

    public float SpecialValue { get; private set; }

    float m_specialMaxValue = 100f;

    public static SpecialGage Instance { get; private set; } = default;
    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            return;
        }
        Destroy(this);
    }

    void Start()
    {
        m_spSlider = GameObject.Find("SpecialGage").GetComponent<Slider>();
        m_spSlider.value = 0;
    }
    
    void Update()
    {
        if(m_spSlider.value == 100)//100になったらtrueになって必殺技が打てる(撃った後はfalseに)
        {
            m_fulledSp = true;
        }
    }
    

    public void ChangeValue(float value)
    {
        SpecialValue += value;
        ChangeUi();
    }

    void ChangeUi()
    {
        //m_spSlider.value = SpecialValue / m_specialMaxValue;
        DOTween.To(() => m_spSlider.value, x => m_spSlider.value = x, SpecialValue / m_specialMaxValue, m_changeTime);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
