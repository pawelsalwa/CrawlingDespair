Shader "Custom/SalwaSectionTransparency"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _TransparencyTex ("TransparencyTex", 2D) = "white" {}
        _alpha ("Alpha", Range(0,1)) = 1
        pos1 ("pos1", Vector) = (0,0,0,0)
        pos2 ("pos2", Vector) = (0,0,0,0)
        teddyPos ("teddyPos", Vector) = (0,0,0,0)
        camPos ("camPos", Vector) = (0,0,0,0)
    }
    SubShader
    {
        Tags {"RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
       // #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma surface surf Standard fullforwardshadows alpha:fade
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _TransparencyTex;

        struct Input
        {
            float2 uv_MainTex;
            float4 screenPos;
        };

        half _alpha;
        float2 pos1;
        float2 pos2;
        float2 teddyPos;
        float3 camPos;
        
        //half _Metallic;
        
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        
        bool LineSegmentsIntersect(float2 lineOneA, float2 lineOneB, float2 lineTwoA, float2 lineTwoB)
		{
			return (((lineTwoB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) > (lineTwoA.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneB.y) * (lineTwoA.x - lineOneB.x) > (lineTwoA.y - lineOneB.y) * (lineTwoB.x - lineOneB.x)) &&
			        ((lineTwoA.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)));
		}
        
        float xdd(Input IN) 
        {
            float value = LineSegmentsIntersect(pos1, pos2, teddyPos, camPos.xz);
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            float transparency = 1 - tex2D(_TransparencyTex, screenUV).x;
            return value ? transparency : 1;
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            // o.Metallic = _Metallic;
            // o.Smoothness = _Glossiness;
            o.Alpha = xdd(IN);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
