Shader "Custom/GridShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _GridSize ("Grid Size", Range(1,100)) = 5
        _GridLineWidth ("Grid Line Width", Range(0.01,0.1)) = 0.02
        _GridTrans ("Grid Transparancy", Range(0.0,1.0)) = 0.1
        _GridColor ("Grid Color", Color) = (0.45,0.45,0.45,1) 

        

    }
    SubShader
    {
         Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float _GridSize; 
            float _GridLineWidth; 
            fixed4 _GridColor;
            float _GridTrans; 

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 _xy=i.uv;

                _xy = i.uv- float2(0.5,0.5);

                _xy*=_GridSize;
               
                fixed4 _col = fixed4(1,1,1,1)*frac(_xy).x*0.0;

                float2 frac_xy=frac(_xy);

                
                if(frac_xy.x>=0.50-_GridLineWidth&&frac_xy.x<=0.50+_GridLineWidth)
                {
                    _col=_GridColor;
                    _col.a=_GridTrans;
                }
                if(frac_xy.y>=0.50-_GridLineWidth&&frac_xy.y<=0.50+_GridLineWidth)
                {
                    _col=_GridColor;
                    _col.a=_GridTrans;
                }

                return _col;
            }
            ENDCG
        }
    }
}
