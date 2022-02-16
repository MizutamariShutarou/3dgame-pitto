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
    public static ReloadTimeController Instance { get; private set; } = default;

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
        m_reloadSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartReloadTime()//リロード中のラグを表示。ラグが終わったらm_reloadSlider.valueを0に戻す
    {
        DOTween.To(() => m_reloadSlider.value, x => m_reloadSlider.value = x, m_reloadMaxValue, m_changeTime).OnComplete(() => m_reloadSlider.value = 0);
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

}

