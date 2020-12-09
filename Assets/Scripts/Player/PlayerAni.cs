using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{

    public Animator ani;
    InputC m_Input;
    // Start is called before the first frame update
    void Start()
    {
        ani = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        m_Input = FindObjectOfType<InputC>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetFloat("horizontal",Mathf.Abs(m_Input.m_Movement.x));//取绝对值
        ani.SetFloat("vertical", Mathf.Abs(m_Input.m_Movement.y));
    }
}
