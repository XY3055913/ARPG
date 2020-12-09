using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{

    public static PlayerC instance; 


    private float walkSpeed=4.5f;

    private CharacterController controller;
    InputC m_Input;




    private void Awake()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        m_Input = FindObjectOfType<InputC>();
    }

    private void OnEnable()
    {
        InputC.instance.InputEventUpdate += FuncUpdate;
    }


    /// <summary>
    /// 移动方法
    /// </summary>
    private void Move()
    {
        //float H = Input.GetAxis("Horizontal");
        //float V = Input.GetAxis("Vertical");
        //TransformDirection：方向变换
       
    }


    void FuncUpdate(Vector2 m_Movement) 
    {
        Vector3 dir = transform.TransformDirection(new Vector3(m_Movement.x, -1, m_Movement.y));

        controller.Move(dir * walkSpeed * Time.deltaTime);


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Move();
    }

    private void OnDisable()
    {
        InputC.instance.InputEventUpdate -= FuncUpdate;
    }
}
