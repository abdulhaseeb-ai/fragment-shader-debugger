using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderDebugger : MonoBehaviour
{
    public static ShaderDebugger Instance;

    [Header("Pixel Prefab")]
    public GameObject m_Pixel_Prefab;
    public GameObject m_Container_Pixel;

    [Space(5)]
    public int m_X_GridSize;
    public int m_Y_GridSize;

    [Space(5)]
    public float m_DistanceBetweenPixels;

    [Range(0.1f, 1f)]
    public float m_Scale_Pixel;

    [Space(10)]
    public GameObject m_ClearContainer_Prefab;




    [Space(20)]
    public Color m_Color_PixelMSGTexts;

    int[,] _uv;
    GameObject[,] _uv_pixels;



    // **  Temporary Variables  **//
    bool _ShowScreenCenterPixels;



    [ContextMenu("Draw Grid")]
    public void DrawGrid()
    {
        _uv = new int[m_X_GridSize, m_Y_GridSize];
        _uv_pixels = new GameObject[m_X_GridSize, m_Y_GridSize];

        ClearContainer();

        float _x_start = ((m_X_GridSize - 1.0f) / 2.0f) * m_DistanceBetweenPixels;
        float _y_start = ((m_Y_GridSize - 1.0f) / 2.0f) * m_DistanceBetweenPixels;

        for (int x = 0; x < m_Y_GridSize; x++)
        {
            for (int y = 0; y < m_Y_GridSize; y++)
            {
                GameObject _Pixel = (GameObject)Instantiate(m_Pixel_Prefab, m_Container_Pixel.transform);
                Vector3 _SpawnPosition = Vector3.zero;

                float _xPosition = _x_start - x * m_DistanceBetweenPixels;
                float _yPosition = _y_start - y * m_DistanceBetweenPixels;
                float _zPosition = 0;
                _SpawnPosition = new Vector3(_xPosition, _yPosition, _zPosition);

                _Pixel.transform.position = _SpawnPosition;
                _Pixel.transform.localScale = Vector3.one * m_Scale_Pixel;

                _Pixel.GetComponent<Pixel>().Set_uv(x, y);
                _uv_pixels[x, y] = _Pixel;
            }
        }
    }


    [ContextMenu("Set Pixel MSG Text Color")]
    public void SetPixelsMSGTextsColor()
    {
        for (int x = 0; x < m_Y_GridSize; x++)
        {
            for (int y = 0; y < m_Y_GridSize; y++)
            {
                _uv_pixels[x, y].GetComponent<Pixel>().SetMSGTextsColor(m_Color_PixelMSGTexts);
            }
        }
    }


    [ContextMenu("Apply Changes In Editor Mode")]
    public void ApplyChangesInEditorMode()
    {
        ApplyChangesToPixels();
    }

    //[ContextMenu("Show Screen Center PIxels")]
    //public void ShowScreenCenterPixels()
    //{
    //    _ShowScreenCenterPixels = !_ShowScreenCenterPixels;

    //    for (int x = 0; x < m_Y_GridSize; x++)
    //    {
    //        for (int y = 0; y < m_Y_GridSize; y++)
    //        {
    //            _uv_pixels[x, y].GetComponent<Pixel>().SetMSGTextsColor(m_Color_PixelMSGTexts);
    //        }
    //    }
    //}

    void ClearContainer()
    {
        if (m_Container_Pixel != null)
        {
            DestroyImmediate(m_Container_Pixel);
        }

        m_Container_Pixel = Instantiate(m_ClearContainer_Prefab);
        m_Container_Pixel.transform.position = Vector3.zero;
        m_Container_Pixel.name = "Container-Pixels";
    }







    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        DrawGrid();
        SetPixelsMSGTextsColor();
    }

    void Update()
    {
        ApplyChangesToPixels();
    }



    void ApplyChangesToPixels()
    {
        for (int x = 0; x < m_Y_GridSize; x++)
        {
            for (int y = 0; y < m_Y_GridSize; y++)
            {


                /////       Your Shader Code Area 



                Color _color = new Color(0, 0, 0, 1);

                /// Normalizing the coordinates to 0-1
                Vector2 uv = new Vector2((x * 1.0f) / (m_X_GridSize - 1), (y * 1.0f) / (m_Y_GridSize - 1));

                /// Scalling the uv Coordinates
                //uv = uv - new Vector2(0.5f, 0.5f);

                /// Animating the uv Coordinates
                uv += Vector2.one * (Mathf.Sin(Time.time) * 0.5f + 0.5f) * 0.3f;

                _color = new Color(uv.x, 0, 0, 1);



                /////       Your Shader Code Area 


                _uv_pixels[x, y].GetComponent<Pixel>().UpdatePixel(_color);

                // 0,1 index used for pixel index , and its color
                // used any index    2,3,4,5    to display your msgs
                // You can also use index    0,1   to display your msgs
                _uv_pixels[x, y].GetComponent<Pixel>().PrintMSGOnPixel(uv.ToString(), 2);
            }
        }
    }
    
    public decimal Frac(decimal value) 
    { 
        return value - Math.Truncate(value); 
    }
}
