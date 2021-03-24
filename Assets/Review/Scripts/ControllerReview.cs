using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerReview : MonoBehaviour
{
    const float Speed = 10f;

    Vector2 moveInput;
    Vector2 mousePosition;
    Vector3 mousePosition3D;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        LookAtMouse();
    }


    void LookAtMouse()
    {
        transform.up = mousePosition3D - transform.position;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(moveInput * Speed, ForceMode2D.Impulse);
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition3D = new Vector3(mousePosition.x, mousePosition.y, 0);

        // Maybe can fixe this to use mousePosition(Vector2D)
        transform.up = mousePosition3D - transform.position;
    }
}
