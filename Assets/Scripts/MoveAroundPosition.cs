using UnityEngine;

public class MoveAroundPosition : MonoBehaviour
{
    public SelectAxis axis;
    public float speed;
    public float magnitude;

    float defaultAxisValue;
    Vector3 temp;

    void Start()
    {
        InitDefaultValue();
    }

    void FixedUpdate()
    {
        MoveBetween();
    }

    void InitDefaultValue()
    {
        temp = gameObject.transform.position;

        if (axis == SelectAxis.x)
        {
            defaultAxisValue = temp.x;
        }
        else if (axis == SelectAxis.y)
        {
            defaultAxisValue = temp.y;
        }
        else
        {
            defaultAxisValue = temp.z;
        }
    }

    void MoveBetween()
    {
        if (axis == SelectAxis.x)
        {
            temp.x += speed * Time.deltaTime;
            Clamped(temp.x);
        }
        else if (axis == SelectAxis.y)
        {
            temp.y += speed * Time.deltaTime;
            Clamped(temp.y);
        }
        else
        {
            temp.z += speed * Time.deltaTime;
            Clamped(temp.z);
        }
        gameObject.transform.position  = temp;
    }

    void Clamped(float current)
    {
        if (Mathf.Abs(current - defaultAxisValue) >= magnitude)
        {
            speed = -speed;
        }
    }
}
