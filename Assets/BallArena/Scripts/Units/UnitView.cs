using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView : PooledGameObject
{
    [SerializeField] private Renderer render;

    private Color startColor;
    private Vector3 startPosition;

    private void Awake()
    {
        startColor = render.material.color;
        startPosition = transform.position;
    }

    public void SetColor(Color color)
    {
        render.material.color = color;
    }

    public override void Clear()
    {
        SetColor(startColor);
        transform.position = startPosition;
    }
}
