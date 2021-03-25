using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// FIXME change speed of current "Ball"

// Has a freeze timer after spawn
// Has a timer for lifetime
// Clamp in screen
// Destroy when fall bottom of the screen
// Monitor "EffectUtils.SpeedBoost" for change speed
public class ClampInScreenBoxCollider : MonoBehaviour
{
    Rigidbody2D rb2D;
    Vector3 position;

    float width;
    float height;

 
    // Methods
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        width = GetComponent<BoxCollider2D>().size.x;
        height = GetComponent<BoxCollider2D>().size.y;
    }

    void FixedUpdate()
    {
        ClampInScreen();
    }

    // Revert vectors for screen resolution
    void ClampInScreen()
    {
        position = transform.position;

        // Axis X
        if (position.x - width / 2 < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + width / 2;
        }
        else if (position.x + width / 2 > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - width / 2;
        }

        // Axis Y
        if (position.y - height / 2 < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + height / 2;
        }
        else if (position.y + height / 2 > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - height / 2;
        }

        transform.position = position;
    }
}
