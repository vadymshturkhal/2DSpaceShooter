using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HitEffectIncRed
{
    static float minGreenColor = 0.3f;

    static int defaultHealthPoints;

    static float red;
    static float green;
    static float blue;
    static float alpha;

    static public float CalculateIncStep(SpriteRenderer spriteRenderer, int defaultHealthPoints)
    {
        return (float)(spriteRenderer.color.g - minGreenColor) / defaultHealthPoints;
    }

    static public void IncrementRedComponent(SpriteRenderer spriteRenderer, float step)
    {
        red = spriteRenderer.color.r;
        green = spriteRenderer.color.g;
        blue = spriteRenderer.color.b;
        alpha = spriteRenderer.color.a;

        green -= step;
        blue -= step;

        spriteRenderer.color = new Color(red, green, blue, alpha);
    }

    static public void SetDefaultColor(SpriteRenderer spriteRenderer)
    {
        spriteRenderer.color = Color.white;
    }
}
