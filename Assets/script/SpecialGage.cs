using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SpecialGage : MonoBehaviour
{
    [SerializeField] Slider m_spSlider = default;
    int m_reset = 0;
    float m_changeTime;
    float m_time;
    // Start is called before the first frame update
    void Start()
    {
        m_spSlider = GameObject.Find("Slider").GetComponent<Slider>();
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
        DOTween.To(() => m_spSlider.value, x => m_spSlider.value = x, value, m_changeTime);
    }
}
