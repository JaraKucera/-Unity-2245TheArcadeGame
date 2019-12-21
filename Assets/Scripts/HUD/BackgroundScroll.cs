using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scroll_speed = 0.05f;
    private MeshRenderer mesh;
    void Start() => mesh = GetComponent<MeshRenderer>();
    void Update()
    {
        float y = Time.time * scroll_speed;
        Vector2 offset = new Vector2(0, y);
        mesh.sharedMaterial.SetTextureOffset("_MainTex", offset);//get main texture and change its offset by given y value manipulated by time
    }
}
