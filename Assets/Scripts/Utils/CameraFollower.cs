using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollower : MonoBehaviour
{
    const float DefaultCameraZAxis = -10f;
    const float MaxCameraDistanceFromPlayer = 5f;

    [SerializeField]
    bool dynamicCamera = true;
    float step;
    float moveSpeed = 10f;
    [SerializeField]
    [Range(0, 0.75f)]
    float freeCameraMouseTracking = 0.5f;

    [SerializeField]
    GameObject target;

    Vector3 cameraPosition;
    Vector3 mousePosition;
    Vector3 desiredPosition;
    Vector3 difference;

    void Awake()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void FixedUpdate()
    {
        SetCameraPosition(dynamicCamera);
    }

    void SetCameraPosition(bool dynamic)
    {
        if (!dynamic)
        {
            cameraPosition = target.transform.position;
            cameraPosition.z = DefaultCameraZAxis;
            transform.position = cameraPosition;
        }
        else
        {
            SetCameraDynamicPosition();
        }
    }

    public void GetMousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        difference = mousePosition - target.transform.position;
    }

    void SetCameraDynamicPosition()
    {
        desiredPosition = Vector3.Lerp(target.transform.position, target.transform.position + difference, freeCameraMouseTracking);

        desiredPosition = desiredPosition - target.transform.position;
        desiredPosition = target.transform.position + Vector3.ClampMagnitude(desiredPosition, MaxCameraDistanceFromPlayer);

        desiredPosition.z = DefaultCameraZAxis;
        transform.position = desiredPosition;
    }
}
