using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollower : MonoBehaviour
{
    const float DefaultCameraZAxis = -10f;

    [SerializeField]
    bool stationalFollower = true;
    float step;
    float moveSpeed = 10f;
    float minDistanceToTarget = 5f;

    [SerializeField]
    GameObject target;

    Vector3 cameraPosition;
    Vector3 mousePosition;
    Vector3 from;
    Vector3 to;


    void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        SetCameraPosition(stationalFollower);
    }

    void SetCameraPosition(bool stational)
    {
        cameraPosition = target.transform.position;
        cameraPosition.z = DefaultCameraZAxis;
        gameObject.transform.position = cameraPosition;

        if (!stational)
        {
            SetCameraDynamicPosition(cameraPosition);
        }
    }

    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    void SetCameraDynamicPosition(Vector3 cameraPos)
    {
        print(Vector3.Distance(transform.position, mousePosition));

        step = moveSpeed * Time.deltaTime;
        from = gameObject.transform.position;
        to = mousePosition;

        if (Vector3.Distance(from, to) <= minDistanceToTarget)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(from, to, step);
    }
}
