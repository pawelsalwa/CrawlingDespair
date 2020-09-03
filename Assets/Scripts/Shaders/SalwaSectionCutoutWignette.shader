Shader "Custom/SalwaSectionCutoutWignette"
 {
     Properties
     {
         _Color ("Main Color", Color) = (1,1,1,1)
         _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
         _AlphaTex ("Alpha", 2D) = "white" {}
         _Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
         pos1 ("pos1", Vector) = (0,0,0,0)
         pos2 ("pos2", Vector) = (0,0,0,0)
         teddyPos ("teddyPos", Vector) = (0,0,0,0)
         camPos ("camPos", Vector) = (0,0,0,0)
     }
 
     SubShader
     {
         Tags {"Queue"="AlphaTest" "IgnoreProjector"="True" "RenderType"="TransparentCutout"}
         LOD 300
         
         CGPROGRAM
         #pragma surface surf Lambert alphatest:_Cutoff
 
         sampler2D _MainTex;
         sampler2D _AlphaTex;
         fixed4 _Color;
        float2 pos1;
        float2 pos2;
        float2 teddyPos;
        float3 camPos;
 
         struct Input
         {
             float2 uv_MainTex;
             float2 uv_AlphaTex;
            float4 screenPos;
         };
         
         bool LineSegmentsIntersect(float2 lineOneA, float2 lineOneB, float2 lineTwoA, float2 lineTwoB)
		{
			return (((lineTwoB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x) > (lineTwoA.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneB.y) * (lineTwoA.x - lineOneB.x) > (lineTwoA.y - lineOneB.y) * (lineTwoB.x - lineOneB.x)) &&
			        ((lineTwoA.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoA.x - lineOneA.x)) !=
			        ((lineTwoB.y - lineOneA.y) * (lineOneB.x - lineOneA.x) > (lineOneB.y - lineOneA.y) * (lineTwoB.x - lineOneA.x)));
		}
        
        float GetTransparency(Input IN) 
        {
            bool value = LineSegmentsIntersect(pos1, pos2, teddyPos, camPos.xz);
            float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
            float transparency = 1 - tex2D(_AlphaTex, screenUV).x;
            return value ? transparency : 1;
        }
 
         void surf (Input IN, inout SurfaceOutput o)
         {
             fixed4 MAIN = tex2D(_MainTex, IN.uv_MainTex) * _Color;
             fixed4 ALPHA = tex2D(_AlphaTex, IN.uv_AlphaTex);
             o.Albedo = MAIN.rgb;
             o.Alpha = GetTransparency(IN);
         }
         ENDCG
     }
 
     FallBack "Transparent/Cutout/Diffuse"
 }