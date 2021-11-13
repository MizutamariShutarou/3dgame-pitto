using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] Vector3 m_targetPos;
    [SerializeField] Image m_aimImage;
    //GameObject hitObj = default;
    GameObject m_player = default;
    GameObject m_wall = default;
    
    private void Start()
    {
        m_player = GameObject.FindWithTag("Player");
        m_wall = GameObject.FindWithTag("Wall");

    }
    void OnEnable()
    {
        // マウスカーソルを消すには、以下の行をアンコメントする
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
        //m_targetPos.z = 100;

        //Vector3 dir = 

        if (Physics.Raycast(ray, out hit))
        {
            // RayがColliderと衝突した地点の座標を取得
            m_targetPos = hit.point;
            //print(m_targetPos);

            if (hit.transform.CompareTag("Enemy"))
            {
                // 照準器を赤色に変化させる。
                //Debug.Log("Enemy");
                m_aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                GameObject get = hit.collider.gameObject;
                
                Vector3 v = m_player.transform.position - get.transform.position;
                float angle = Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg;
                float angle2 = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
                float angle3 = Mathf.Atan2(v.y, v.z) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.Euler(angle3, angle, angle2);
                m_player.transform.localRotation = q;
            }
            else if(hit.transform.CompareTag("Wall"))//wallにRayがあたった時は
            {
                // 照準器の色は白
                //Debug.Log("Wall");
                m_aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                //GameObject get = hit.collider.gameObject;

                Vector3 v = m_player.transform.position - m_wall.transform.position;
                float angle = Mathf.Atan2(v.x, v.z) * Mathf.Rad2Deg;
                float angle2 = Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
                float angle3 = Mathf.Atan2(v.y, v.z) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.Euler(angle3, angle, angle2);
                m_player.transform.localRotation = q;
            }
            
        }
        //else
        //{
        //    // 照準器の色は白
        //    m_aimImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            
        //}
        
    }
}