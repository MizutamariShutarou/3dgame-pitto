using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] Vector3 m_targetPos;
    [SerializeField] Image m_aimImage;
    //GameObject hitObj = default;
    //GameObject m_player = default;
    //GameObject m_wall = default;
    
    private void Start()
    {
        //m_player = GameObject.FindWithTag("Player");
    }
    void OnEnable()
    {
        // マウスカーソルを消す
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }
    void Update()
    {
        // 「マウスの位置」と「照準器の位置」を同期させる。
        transform.position = Input.mousePosition;

        RaycastHit hit;

        // MainCameraからマウスの位置にRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // RayがColliderと衝突した地点の座標を取得
            m_targetPos = hit.point;
            //print(m_targetPos);

            if(hit.transform.CompareTag("Enemy") || hit.transform.CompareTag("Boss"))
            {
                // 照準器を赤色に変化させる。
                //Debug.Log("Enemy");
                m_aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else if(hit.transform.CompareTag("Wall"))
            {
                // 照準器の色は白
                m_aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            
        }
        

    }
}