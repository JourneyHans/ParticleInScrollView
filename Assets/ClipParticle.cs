using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipParticle : MonoBehaviour
{
    public RectTransform TargetArea;
    public Transform CanvasTransform;

    void Start()
    {
        if (TargetArea != null)
        {
            ClippingWithView();
        }
    }

    private void ClippingWithView()
    {
        float canvasScale = CanvasTransform.localScale.x;
        float halfWidth = TargetArea.rect.size.x * 0.5f * canvasScale;
        float halfHeight = TargetArea.rect.size.y * 0.5f * canvasScale;

        Vector4 area = new Vector4
        {
            x = TargetArea.position.x - halfWidth,
            y = TargetArea.position.y - halfHeight,
            z = TargetArea.position.x + halfWidth,
            w = TargetArea.position.y + halfHeight,
        };

        Debug.Log(area);

        ParticleSystem[] particles = transform.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
        {
            foreach (Material material in particle.GetComponent<Renderer>().materials)
            {
                material.SetVector("_Area", area);
            }
        }
    }
}
