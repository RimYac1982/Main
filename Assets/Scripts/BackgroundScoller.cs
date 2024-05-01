using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(0f, 6f)]
    public float scrollSpeed = 0.5f;

    private float offset;
    private Material mat;


    void Start()
    {
        // Check if the GameObject has a Renderer component and a Material assigned to it
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && renderer.material != null)
        {
            mat = renderer.material;
        }
        else
        {
            
        }
    }

    void Update()
    {
        if (mat != null) // Check if the 'mat' variable is not null before using it
        {
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else
        {
          
        }
   
    }
}
