Shader "Custom/InsideOutShader"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}  // 这里定义 Main Texture
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull Front  // 反转法线，让球体内部可见

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;  // 纹理采样器
            float4 _MainTex_ST;  // 纹理缩放 & 偏移

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);  // 处理 UV 坐标
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                return tex2D(_MainTex, i.uv);  // 采样纹理
            }
            ENDCG
        }
    }
}
