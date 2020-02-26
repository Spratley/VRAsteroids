using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(RobertsCrossOutlineRenderer), PostProcessEvent.BeforeTransparent, "PostProcess/RobertsCrossEdge")]
public sealed class RobertsCrossOutline : PostProcessEffectSettings
{  
    public ColorParameter color = new ColorParameter {value = Color.white};

    public IntParameter scale = new IntParameter { value = 1 };
    
    public FloatParameter depthThresh = new FloatParameter { value = 0.2f };
    [Range(0, 1)]
    public FloatParameter normalThresh = new FloatParameter { value = 0.4f };

    [Range(0, 1)]
    public FloatParameter depthNormalThresh = new FloatParameter { value = 0.5f };
    public FloatParameter depthNormalThreshScale = new FloatParameter { value = 7 };
    
}

public sealed class RobertsCrossOutlineRenderer : PostProcessEffectRenderer<RobertsCrossOutline>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/PostProcess/RobertsCrossEdge"));
        sheet.properties.SetColor("_Color", settings.color);
        sheet.properties.SetInt("_Scale", settings.scale);
        sheet.properties.SetFloat("_EdgeThreshDepth", settings.depthThresh);
        sheet.properties.SetFloat("_EdgeThreshNorm", settings.normalThresh);
        sheet.properties.SetFloat("_DepthNormalThresh", settings.depthNormalThresh);
        sheet.properties.SetFloat("_DepthNormalThreshScale", settings.depthNormalThreshScale);


        Matrix4x4 clipToView = GL.GetGPUProjectionMatrix(context.camera.projectionMatrix, true).inverse;
        sheet.properties.SetMatrix("_ClipToView", clipToView);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}