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
    
    // Start is called before the first frame update
    void Start()
    {
        m_reloadSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            DOTween.To(() => m_reloadSlider.value, x => m_reloadSlider.value = x, m_reloadMaxValue, m_changeTime);
            if(m_reloadSlider.value == m_reloadMaxValue)
            {
                m_reloadSlider.value -= m_reloadMaxValue;
            }
        }
    }
    //public void ChangeValue(float value)
    //{
    //    ReloadValue += value;
    //    ChangeUI();
    //}

    //public void ResetValue()
    //{
    //    m_reloadSlider.value = 0;
    //}

    
        //m_spSlider.value = SpecialValue / m_specialMaxValue;
       
    
}
