using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputC : MonoBehaviour
{
    public static InputC instance;
    public Vector2 m_Movement;
    public Vector3 m_Camera;

    public event UnityAction<Vector2> InputEventUpdate;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse ScrollWheel"));
        InputEventUpdate(m_Movement);


    }
}
,