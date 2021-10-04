using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTexture : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int _materialIndex = 0;
    public Color[] colors;

    void Start()
    {
        Material mat = meshRenderer.materials[_materialIndex];
        mat.color = colors[Random.Range(0, colors.Length)];
    }
}
