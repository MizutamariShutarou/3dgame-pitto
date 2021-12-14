using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpecialGage : MonoBehaviour
{
    [SerializeField] public Slider m_spSlider = default;
    [SerializeField] GameObject m_enemys;
    int m_reset = 0;
    float m_changeTime;
    float m_time;
    // Start is called before the first frame update
    void Start()
    {
        m_spSlider = GameObject.Find("Slider").GetComponent<Slider>();
        //m_enemys = GameObject.FindWithTag("Enemy");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Change(float value)
    {
        ChangeValue(m_spSlider.value + value);
    }

    public void ChangeValue(float value)
    {
        DOTween.To(() => m_spSlider.value, x => m_spSlider.value = x, value, m_changeTime);//.SetLink(m_enemys.gameObject);
    }
}
