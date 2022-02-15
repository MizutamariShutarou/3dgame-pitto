using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    [SerializeField] public Slider m_hpSlider = default; 
    [SerializeField] float m_changeTime;
    public float HpValue { get; set; }

    float m_hpMaxValue = 10f;

    public static HPController Instance { get; private set; } = default;
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
        m_hpSlider = GameObject.Find("HpSlider").GetComponent<Slider>();
        m_hpSlider.value = 10f;
        HpValue = 10f;
    }

    void Update()
    {
        
    }


    public void ChangeValue(float value)
    {
        HpValue -= value;
        //Debug.Log(HpValue);
        ChangeUI();
    }

    void ChangeUI()
    {
        //m_spSlider.value = SpecialValue / m_specialMaxValue;
        DOTween.To(() => m_hpSlider.value, x => m_hpSlider.value = x, HpValue / m_hpMaxValue, m_changeTime);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
