// Shader created with Shader Forge Beta 0.36 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.36;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:True,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:True;n:type:ShaderForge.SFN_Final,id:1,x:32585,y:32637|diff-121-OUT,spec-124-RGB,gloss-125-OUT,emission-126-OUT,alpha-131-OUT;n:type:ShaderForge.SFN_Multiply,id:121,x:32932,y:32476|A-122-RGB,B-123-RGB;n:type:ShaderForge.SFN_Color,id:122,x:33171,y:32402,ptlb:Diffuse Colour,ptin:_DiffuseColour,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:123,x:33171,y:32551;n:type:ShaderForge.SFN_Color,id:124,x:33027,y:32629,ptlb:Specular Colour,ptin:_SpecularColour,cmnt:Specular Colour,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:125,x:33142,y:32762,ptlb:Glossiness,ptin:_Glossiness,cmnt:Glossiness,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Multiply,id:126,x:32886,y:32980|A-129-RGB,B-127-OUT,C-130-OUT;n:type:ShaderForge.SFN_Fresnel,id:127,x:33147,y:33014|EXP-128-OUT;n:type:ShaderForge.SFN_Slider,id:128,x:33348,y:32983,ptlb:Rim Thickness,ptin:_RimThickness,min:0,cur:1,max:2;n:type:ShaderForge.SFN_Color,id:129,x:33147,y:32865,ptlb:Rim Light,ptin:_RimLight,glob:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ValueProperty,id:130,x:33148,y:33171,ptlb:Rim Power,ptin:_RimPower,glob:False,v1:1;n:type:ShaderForge.SFN_Slider,id:131,x:32868,y:32807,ptlb:Alpha,ptin:_Alpha,min:0,cur:0.75,max:1;proporder:122-131-124-125-129-128-130;pass:END;sub:END;*/

Shader "pGem/pGem_Rimlight_Alpha" {
    Properties {
        _DiffuseColour ("Diffuse Colour", Color) = (1,1,1,1)
        _Alpha ("Alpha", Range(0, 1)) = 0.75
        _SpecularColour ("Specular Colour", Color) = (1,1,1,1)
        _Glossiness ("Glossiness", Range(0, 1)) = 0.5
        _RimLight ("Rim Light", Color) = (1,1,1,1)
        _RimThickness ("Rim Thickness", Range(0, 2)) = 1
        _RimPower ("Rim Power", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 2.0
            uniform float4 _LightColor0;
            uniform float4 _DiffuseColour;
            uniform float4 _SpecularColour;
            uniform float _Glossiness;
            uniform float _RimThickness;
            uniform float4 _RimLight;
            uniform float _RimPower;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.vertexColor = v.vertexColor;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb*2;
////// Emissive:
                float3 emissive = (_RimLight.rgb*pow(1.0-max(0,dot(normalDirection, viewDirection)),_RimThickness)*_RimPower);
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = _SpecularColour.rgb;
                float3 specular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (_DiffuseColour.rgb*i.vertexColor.rgb);
                finalColor += specular;
                finalColor += emissive;
/// Final Color:
                return fixed4(finalColor,_Alpha);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 2.0
            uniform float4 _LightColor0;
            uniform float4 _DiffuseColour;
            uniform float4 _SpecularColour;
            uniform float _Glossiness;
            uniform float _RimThickness;
            uniform float4 _RimLight;
            uniform float _RimPower;
            uniform float _Alpha;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.vertexColor = v.vertexColor;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i)*2;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
///////// Gloss:
                float gloss = _Glossiness;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                NdotL = max(0.0, NdotL);
                float3 specularColor = _SpecularColour.rgb;
                float3 specular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow) * specularColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                finalColor += diffuseLight * (_DiffuseColour.rgb*i.vertexColor.rgb);
                finalColor += specular;
/// Final Color:
                return fixed4(finalColor * _Alpha,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
