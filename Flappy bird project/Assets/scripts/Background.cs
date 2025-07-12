using UnityEngine;
using UnityEngine.Rendering;

public class Background : MonoBehaviour
{


    private MeshRenderer MeshRenderer;
    public float AnimationSpeed = 1f;

    private void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        
    }


    void Update()
    {
        MeshRenderer.material.mainTextureOffset += new Vector2(AnimationSpeed * Time.deltaTime, 0);
    }
}
