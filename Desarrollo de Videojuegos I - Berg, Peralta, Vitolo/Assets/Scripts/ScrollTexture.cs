using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private float scrollX = 0;
    [SerializeField] private float scrollY = 0;
    [SerializeField] private Material objectMaterial;

    private void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        objectMaterial.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
