using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float m_ZoomLimit;
    public float m_ZoomSpeed;

    public Vector2 m_MoveSpeed;

    


    void Start()
    {
        m_ZoomLimit = ShaderDebugger.Instance.m_X_GridSize*3;
    }
    
    void Update()
    {

        float _ZoomSpeed = (Camera.main.orthographicSize / m_ZoomLimit) * m_ZoomSpeed;

        if (Mathf.Abs(Input.mouseScrollDelta.y)>0)
        {
            
            float _value= Camera.main.orthographicSize + m_ZoomSpeed * -Input.mouseScrollDelta.y;
            _value = Mathf.Clamp(_value, 1, m_ZoomLimit);
            Camera.main.orthographicSize = _value;
        }

        float _x_input = Input.GetAxis("Mouse X");
        float _y_input = Input.GetAxis("Mouse Y");

        float _xvalue = (ShaderDebugger.Instance.m_X_GridSize * 5.0f) * m_MoveSpeed.x;
        float _yvalue = (ShaderDebugger.Instance.m_Y_GridSize * 5.0f) * m_MoveSpeed.y;

        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(-_x_input* _xvalue, -_y_input* _yvalue, 0) * Time.deltaTime* Camera.main.orthographicSize;
        }
    }
}
