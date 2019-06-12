using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Vector2 uvOffset = Vector2.zero;
    int materialIndex = 0;
    string textureName = "_MainTex";
    private Renderer renderer;
    float prevCameraXPos;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        prevCameraXPos = transform.position.x;
    }

    void Update()
    {

        uvOffset += (new Vector2(0.005f, 0.0f) * (transform.position.x - prevCameraXPos));
        if (renderer.enabled)
        {
            renderer.materials[materialIndex].SetTextureOffset(textureName, uvOffset);
        }
        prevCameraXPos = transform.position.x;
    }
}