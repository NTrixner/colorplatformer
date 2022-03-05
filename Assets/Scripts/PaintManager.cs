using UnityEngine;
using UnityEngine.Rendering;

namespace ColorPlatformer
{
    public class PaintManager : MonoBehaviour
    {
        public Shader texturePaint;

        int texId = Shader.PropertyToID("_MainTex");
        int positionID = Shader.PropertyToID("_PainterPosition");
        int hardnessID = Shader.PropertyToID("_Hardness");
        int strengthID = Shader.PropertyToID("_Strength");
        int radiusID = Shader.PropertyToID("_Radius");
        int colorID = Shader.PropertyToID("_PainterColor");

        public Material paintMaterial;

        CommandBuffer command;

        public void Awake()
        {

            paintMaterial = new Material(texturePaint);
            command = new CommandBuffer();
            command.name = "CommmandBuffer - " + gameObject.name;
        }

        public void initTextures(PaintReceiver receiver)
        {
            RenderTexture renderTex = receiver.renderTexture;
            RenderTexture paintTex = receiver.paintTexture;
            Renderer rend = receiver.renderer;

            command.SetRenderTarget(renderTex);
            command.SetRenderTarget(paintTex);
            command.DrawRenderer(rend, paintMaterial, 0);

            Graphics.ExecuteCommandBuffer(command);
            command.Clear();
        }


        public void paint(PaintReceiver receiver, Vector3 pos, float radius = 1f, float hardness = .5f,
            float strength = .5f, Color? color = null)
        {
            Debug.Log(string.Format("paint(receiver={0}, pos={1}, radius={2}, hardness={3}, strength={4}, color={5}", 
                receiver, pos, radius, hardness, strength, color));
            RenderTexture renderTex = receiver.renderTexture;
            RenderTexture paintTex = receiver.paintTexture;
            Renderer rend = receiver.renderer;
            
            paintMaterial.SetTexture(texId, renderTex);
            paintMaterial.SetVector(positionID, pos);
            paintMaterial.SetFloat(hardnessID, hardness);
            paintMaterial.SetFloat(strengthID, strength);
            paintMaterial.SetFloat(radiusID, radius);
            paintMaterial.SetColor(colorID, color ?? Color.red);

            command.SetRenderTarget(paintTex);
            command.DrawRenderer(rend, paintMaterial, 0);
            
            command.SetRenderTarget(renderTex);
            command.Blit(paintTex, renderTex);

            Graphics.ExecuteCommandBuffer(command);
            command.Clear();
        }
    }
}