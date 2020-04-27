using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleOnlyDuringNight : MonoBehaviour
{
    private LightColorController lightColorController;

    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        lightColorController = FindObjectOfType<LightColorController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        if (spriteRenderer != null && lightColorController != null)
            spriteRenderer.enabled = lightColorController.TimeValue > 0;
    }
}
