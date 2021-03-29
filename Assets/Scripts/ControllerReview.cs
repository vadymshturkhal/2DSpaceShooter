using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerReview : MonoBehaviour
{
    const float PlayerSpeed = 10f;

    Vector2 moveInput;
    Vector2 mousePosition;
    Vector3 mousePosition3D;
    Rigidbody2D rb2D;
    ProjectileHandler projectileHandler;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        GameObject projectile = transform.Find("ProjectileHandler").gameObject;
        projectileHandler = projectile.GetComponent<ProjectileHandler>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(moveInput * PlayerSpeed, ForceMode2D.Impulse);
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition3D = new Vector3(mousePosition.x, mousePosition.y, 0);

        // Maybe can fixe this to use mousePosition(Vector2D)
        transform.up = mousePosition3D - transform.position;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        projectileHandler.Fire(context.performed);
    }
}
