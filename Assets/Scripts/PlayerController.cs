using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    const float PlayerSpeed = 10f;

    public bool paused = false;
    
    [SerializeField]
    GameObject player;

    Vector2 moveInput;
    Vector2 mousePosition;
    Vector3 mousePosition3D;
    Rigidbody2D rb2D;
    ProjectileHandler projectileHandler;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        rb2D = player.GetComponent<Rigidbody2D>();
        GameObject projectile = player.transform.Find("ProjectileHandler").gameObject;
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
        if (paused)
        {
            return;
        }

        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        mousePosition3D = new Vector3(mousePosition.x, mousePosition.y, 0);

        player.transform.up = mousePosition3D - player.transform.position;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        projectileHandler.Fire(context.performed);
    }
}
