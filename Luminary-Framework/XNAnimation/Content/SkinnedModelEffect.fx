// Any change made over these constants require that the SkinnedModelEffect also being updated.
#define SHADER20_MAX_BONES 80
#define MAX_LIGHTS 8

struct PointLight
{
    float3 position;
    float3 color;
};

struct Material
{
    float3 emissiveColor;
    float3 diffuseColor;
    float3 specularColor;
    float specularPower;
};

// Configurations
// -------------------------------------------------
bool diffuseMapEnabled;
bool specularMapEnabled;

// Matrix
// -------------------------------------------------
float4x4 matW  : World;
float4x4 matVI  : ViewInverse;
float4x4 matVP  : ViewProjection;
float4x3 matBones[SHADER20_MAX_BONES];

// Material
// -------------------------------------------------
Material material;

// Light
// -------------------------------------------------
float3 ambientLightColor;
PointLight lights[MAX_LIGHTS];

// Textures and Samplers
// -------------------------------------------------
texture diffuseMap0;
sampler2D diffuseMapSampler = sampler_state {
    texture = <diffuseMap0>;
    MagFilter = Linear;
    MinFilter = Linear;
    MipFilter = Linear;
    AddressU = Wrap;
    AddressV = Wrap;
};

texture normalMap0;
sampler2D normalMapSampler = sampler_state {
    texture = <normalMap0>;
    MagFilter = Linear;
    MinFilter = Linear;
    MipFilter = Linear;
    AddressU = Wrap;
    AddressV = Wrap;
};

texture specularMap0;
sampler2D specularMapSampler = sampler_state {
    texture = <specularMap0>;
    MagFilter = Linear;
    MinFilter = Linear;
    MipFilter = Linear;
    AddressU = Wrap;
    AddressV = Wrap;
};


// Vertex Shaders
// -------------------------------------------------
void AnimatedModelVS_Light(
    in float4 inPosition		: POSITION,
    in float3 inNormal			: NORMAL,
    in float2 inUV0				: TEXCOORD0,
    in float4 inBoneIndex		: BLENDINDICES0,
    in float4 inBoneWeight		: BLENDWEIGHT0,
    
    out float4 outSVPosition	: POSITION,
    out float3 outPosition		: TEXCOORD0,
    out float3 outNormal		: TEXCOORD1,
    out float2 outUV0			: TEXCOORD2,
    out float3 outEyeVector		: TEXCOORD3)
{
    // Calculate the final bone transformation matrix
    float4x3 matSmoothSkin = 0;
    matSmoothSkin += matBones[inBoneIndex.x] * inBoneWeight.x;
    matSmoothSkin += matBones[inBoneIndex.y] * inBoneWeight.y;
    matSmoothSkin += matBones[inBoneIndex.z] * inBoneWeight.z;
    matSmoothSkin += matBones[inBoneIndex.w] * inBoneWeight.w;
    
    // Combine skin and world transformations
    float4x4 matSmoothSkinWorld = 0;
    matSmoothSkinWorld[0] = float4(matSmoothSkin[0], 0);
    matSmoothSkinWorld[1] = float4(matSmoothSkin[1], 0);
    matSmoothSkinWorld[2] = float4(matSmoothSkin[2], 0);
    matSmoothSkinWorld[3] = float4(matSmoothSkin[3], 1);
    matSmoothSkinWorld = mul(matSmoothSkinWorld, matW);
    
    // Transform vertex position and normal
    outPosition = mul(inPosition, matSmoothSkinWorld);
    outSVPosition = mul(float4(outPosition, 1.0f), matVP);
    
    // Transform vertex normal
    outNormal = mul(inNormal, (float3x3)matSmoothSkinWorld);
    
    // Calculate eye vector
    outEyeVector = matVI[3].xyz - outPosition;
    
    // Texture coordinate
    outUV0 = inUV0;
}


void AnimatedModelVS_LightWithNormal(
	in float4 inPosition		: POSITION,
    in float3 inNormal			: NORMAL,
    in float2 inUV0				: TEXCOORD0,
    in float3 inTangent			: TANGENT0,
    in float3 inBinormal		: BINORMAL0,
    in float4 inBoneIndex		: BLENDINDICES0,
    in float4 inBoneWeight		: BLENDWEIGHT0,

	out float4 outSVPosition	: POSITION,
    out float3 outPosition		: TEXCOORD0,
    out float2 outUV0			: TEXCOORD1,
    out float3 outEyeVector		: TEXCOORD2,
    out float3 outTangent		: TEXCOORD3,
    out float3 outBinormal		: TEXCOORD4,
    out float3 outNormal		: TEXCOORD5
	)
{
    // Calculate the final bone transformation matrix
    float4x3 matSmoothSkin = 0;
    matSmoothSkin += matBones[inBoneIndex.x] * inBoneWeight.x;
    matSmoothSkin += matBones[inBoneIndex.y] * inBoneWeight.y;
    matSmoothSkin += matBones[inBoneIndex.z] * inBoneWeight.z;
    matSmoothSkin += matBones[inBoneIndex.w] * inBoneWeight.w;
    
    // Combine skin and world transformations
    float4x4 matSmoothSkinWorld = 0;
    matSmoothSkinWorld[0] = float4(matSmoothSkin[0], 0);
    matSmoothSkinWorld[1] = float4(matSmoothSkin[1], 0);
    matSmoothSkinWorld[2] = float4(matSmoothSkin[2], 0);
    matSmoothSkinWorld[3] = float4(matSmoothSkin[3], 1);
    matSmoothSkinWorld = mul(matSmoothSkinWorld, matW);
    
    // Transform vertex position and normal
    outPosition = mul(inPosition, matSmoothSkinWorld);
    outSVPosition = mul(float4(outPosition, 1.0f), matVP);

	// Matrix to put world space vectors in tangent space
	//float3x3 tangentSpace = float3x3(inTangent, inBinormal, inNormal);
    //float3x3 toTangentSpace = mul(tangentSpace, (float3x3)matSmoothSkin);
	float3x3 tangentSpace = float3x3(inTangent, inBinormal, inNormal);
	float3x3 tangentToWorld = mul(tangentSpace, (float3x3)matSmoothSkinWorld);
    
	// Calculate eye vector
    float3 eyeVector = matVI[3].xyz - outPosition;
    //outEyeVector = mul(toTangentSpace, eyeVector);
	outEyeVector = eyeVector;
	
	// Tangent base
	outTangent = tangentToWorld[0];
	outBinormal = tangentToWorld[1];
	outNormal = tangentToWorld[2];
	
	// Texture coordinate
	outUV0 = inUV0;
}


// Pixel Shaders
// -------------------------------------------------
float3 PhongShadingPS(
	uniform int lightCount,
	in float3 inPosition,
	in float3 inNormal,
	in float3 inEyeVector, 
	in float3 inDiffuseColor,
	in float3 inSpecularColor,
	in float  inSpecularPower)
{
	float3 diffuseLightColor = ambientLightColor * inDiffuseColor;
	float3 specularLightColor = 0;

	for (int i = 0; i < lightCount; i++)
	{
		// Light vector
		float3 lightVector = normalize(lights[i].position - inPosition);

		// Diffuse intensity
		float diffuseIntensity = saturate(dot(inNormal, lightVector));
		
		// Specular intensity
		float3 halfwayVector = normalize(lightVector + inEyeVector);
		float specularIntensity = saturate(dot(inNormal, halfwayVector));
		specularIntensity = pow(specularIntensity, inSpecularPower);
		
		// 
		diffuseLightColor += lights[i].color * diffuseIntensity;
		specularLightColor += lights[i].color * specularIntensity;
	}

	return diffuseLightColor * inDiffuseColor + specularLightColor * inSpecularColor;
}


void animatedModelPS_Light(
	uniform int lightCount,
    in float3 inPosition	: TEXCOORD0,
    in float3 inNormal		: TEXCOORD1,
    in float2 inUV0			: TEXCOORD2,
    in float3 inEyeVector	: TEXCOORD3,

	out float4 outColor0	: COLOR0)
{
    // Normalize all input vectors
    float3 position = normalize(inPosition);
	float3 normal = normalize(inNormal);
    float3 eyeVector = normalize(inEyeVector);
    
    // Reads texture diffuse color
    float3 diffuseColor = material.diffuseColor;
    if (diffuseMapEnabled)
        diffuseColor *= tex2D(diffuseMapSampler, inUV0);
    
    // Reads texture specular color
    float3 specularColor = material.specularColor;
    if (specularMapEnabled)
        specularColor *= tex2D(specularMapSampler, inUV0);
        	
    // Calculate final color
    outColor0.a = 1.0f;
	outColor0.rgb = material.emissiveColor + PhongShadingPS(lightCount, position, normal,
		eyeVector, diffuseColor, specularColor, material.specularPower);
}


void animatedModelPS_LightWithNormal(
	uniform int lightCount,
    in float3 inPosition	: TEXCOORD0,
    in float2 inUV0			: TEXCOORD1,
    in float3 inEyeVector	: TEXCOORD2,
    in float3 inTangent		: TEXCOORD3,
    in float3 inBinormal	: TEXCOORD4,
    in float3 inNormal		: TEXCOORD5,
	
	out float4 outColor0	: COLOR0)
{
    // Normalize all input vectors
	float3 position = normalize(inPosition);
    float3 eyeVector = normalize(inEyeVector);
    
	//float3x3 toTangentSpace = float3x3(
		//normalize(inTangent), normalize(inBinormal), normalize(inNormal));
	float3x3 toTangentSpace = float3x3(inTangent, inBinormal, inNormal);
    
    // Read texture diffuse color
    float3 diffuseColor = material.diffuseColor;
    if (diffuseMapEnabled)
        diffuseColor *= tex2D(diffuseMapSampler, inUV0);
    
    // Reads texture specular color
    float3 specularColor = material.specularColor;
    if (specularMapEnabled)
        specularColor *= tex2D(specularMapSampler, inUV0);
    
    // Read the surface's normal (only use the R and G channels)
    float3 normal = tex2D(normalMapSampler, inUV0);
	normal.xy = normal.xy * 2.0 - 1.0;
	normal.y = -normal.y;
	normal.z = sqrt(1.0 - dot(normal.xy, normal.xy));
    
	// Put normal in world space
	normal = mul(normal, toTangentSpace);

    // Calculate final color
    outColor0.a = 1.0f;
    outColor0.rgb = material.emissiveColor + PhongShadingPS(lightCount, position, normal,
		eyeVector, diffuseColor, specularColor, material.specularPower);
}


// Techniques
// -------------------------------------------------
technique AnimatedModel_NoLight 
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_0"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_0 animatedModelPS_Light(0);
    }
}

technique AnimatedModel_OneLight
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_0"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_0 animatedModelPS_Light(1);
    }
}

technique AnimatedModel_TwoLight
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_0"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_0 animatedModelPS_Light(2);
    }
}

technique AnimatedModel_FourLight
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_b animatedModelPS_Light(4);
    }
}

technique AnimatedModel_SixLight
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_b animatedModelPS_Light(6);
    }
}

technique AnimatedModel_EightLight
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_Light();
        PixelShader = compile ps_2_b animatedModelPS_Light(8);
    }
}

technique AnimatedModel_OneLightWithNormal
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_0"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_LightWithNormal();
        PixelShader = compile ps_2_0 animatedModelPS_LightWithNormal(1);
    }
}

technique AnimatedModel_TwoLightWithNormal
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_0"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_LightWithNormal();
        PixelShader = compile ps_2_0 animatedModelPS_LightWithNormal(2);
    }
}

technique AnimatedModel_FourLightWithNormal
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_LightWithNormal();
        PixelShader = compile ps_2_b animatedModelPS_LightWithNormal(4);
    }
}

technique AnimatedModel_SixLightWithNormal
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_LightWithNormal();
        PixelShader = compile ps_2_b animatedModelPS_LightWithNormal(6);
        
    }
}

technique AnimatedModel_EightLightWithNormal
< string vertexShaderProfile = "VS_2_0"; string pixelShaderProfile = "PS_2_b"; >
{
    pass p0
    {
		AlphaBlendEnable = FALSE;
		
        VertexShader = compile vs_2_0 AnimatedModelVS_LightWithNormal();
        PixelShader = compile ps_2_b animatedModelPS_LightWithNormal(8);
    }
}