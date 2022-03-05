using System;
using ColorPlatformer;
using UnityEngine;

public class PaintReceiver : MonoBehaviour
{
    private const int TEXTURE_SIZE = 1024;

    public RenderTexture renderTexture;

    public RenderTexture paintTexture;
    
    public Renderer renderer;

    private int maskTextureID = Shader.PropertyToID("_MaskTexture");
    private PaintManager paintManager;

    private void Start()
    {
        paintManager = FindObjectOfType<PaintManager>();
        renderTexture = new RenderTexture(TEXTURE_SIZE, TEXTURE_SIZE, 0);
        renderTexture.filterMode = FilterMode.Bilinear;
        renderTexture.name = "Mask";

        paintTexture = new RenderTexture(TEXTURE_SIZE, TEXTURE_SIZE, 0);
        paintTexture.filterMode = FilterMode.Bilinear;
        paintTexture.name = "Paint";
        
        renderer = GetComponent<Renderer>();
        renderer.material.SetTexture(maskTextureID, renderTexture);
        
        paintManager.initTextures(this);
    }

    public void ReceivePaint(Vector3 point, Vector3 normal, Color c)
    {
        paintManager.paint(this, point, 1f, 0.5f, 1f, c);
    }
    
    void OnDisable(){
        renderTexture.Release();
    }
}
