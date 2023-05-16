using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Pixel : MonoBehaviour
{
    public int _x_uv;
    public int _y_uv;

    public TextMesh[] m_MSG_Texts;

    [Space(10)]
    public GameObject m_BoundaryBG;




    public void Set_uv(int _x,int _y)
    {
        _x_uv = _x;
        _y_uv = _y;
        m_MSG_Texts[0].text = "[" + _x.ToString() + "," + _y.ToString() + "]";
    }




    public void UpdatePixel(Color _Color)
    {
        UpdateColor(_Color);
    }

    public void UpdateColor(Color _Color)
    {
        GetComponent<MeshRenderer>().material.color = _Color;
        float r = (float)System.Math.Round(_Color.r, 2);
        float g = (float)System.Math.Round(_Color.g, 2);
        float b = (float)System.Math.Round(_Color.b, 2);
        float a = (float)System.Math.Round(_Color.a, 2);

        m_MSG_Texts[1].text = "(" + r.ToString() + "," + g.ToString() + "," + b.ToString() + "," + a.ToString() + ")";
    }

    public void PrintMSGOnPixel(string _MSG, int _Index)
    {
        m_MSG_Texts[_Index].text = _MSG;
    }



    public void SetMSGTextsColor(Color _Color)
    {
        for(int i=0;i<m_MSG_Texts.Length;i++)
        {
            m_MSG_Texts[i].color = _Color;
        }
    }
}
