using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARPGCameraC : MonoBehaviour
{

    public Transform target;//目标
    public float targetHeight=1.5f;//跟随高度
    public float targetSide=-0.1f;//水平偏移值
    public float distance=4;//与目标的距离
    public float maxDistance=8;//最大距离
    public float minDistance=2.2f;//最小距离
    public float xSpeed=250;//鼠标 x 速度
    public float ySpeed=125;//鼠标 y 速度
    public float yMinLimit=-10;//旋转限制角度
    public float yMaxLimit=72;//旋转限制角度
    public float zoomRate=80;//鼠标缩放倍速，快慢

    public float x=20;
    public float y=0;

    InputC m_Input;
    private void Awake()
    {
        m_Input = FindObjectOfType<InputC>();

        //鼠标箭头
        Cursor.lockState = CursorLockMode.Locked;//锁定
        Cursor.visible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void LateUpdate()
    {
        x += m_Input.m_Camera.x * xSpeed * Time.deltaTime;
        y -= m_Input.m_Camera.x * xSpeed * Time.deltaTime;
        distance -= (m_Input.m_Camera.z * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        y = ClampAngle(y,yMinLimit,yMaxLimit);
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        transform.rotation = rotation;

        if (m_Input.m_Camera.x !=0||m_Input.m_Camera.y!=0)
        {
            target.transform.rotation = Quaternion.Euler(0, x, 0);
        }
        transform.position = target.position-((rotation * new Vector3(targetSide,0,1)*distance-new Vector3(0,targetHeight,0)));



    }






    /// <summary>
    /// 角度修正
    /// </summary>
    /// <returns></returns>
    float ClampAngle(float angle,float min,float max)
    {

        if (angle <- 360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }



        return Mathf.Clamp(angle,min,max);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
