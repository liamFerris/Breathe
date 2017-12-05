// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Unlit shader. Simplest possible colored shader.
// - no lighting
// - no lightmap support
// - no texture
Shader "Custom/Unlit-NoFog" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 100
    
    Pass {  
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            uniform sampler2D _MainTex;
            struct appdata_t {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };
            struct v2f {
                float4 vertex : SV_POSITION;
                float4 uv : TEXCOORD0;
            };
            fixed4 _Color;
            
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = float4( v.texcoord.xy, 0, 0 );
                return o;
            }
            
            fixed4 frag (v2f i) : COLOR
            {
                fixed4 c = tex2D(_MainTex, i.uv) * _Color;
                UNITY_OPAQUE_ALPHA(c.a);
                return c;
            }
        ENDCG
    }
}
}