using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CatapultController : MonoBehaviour
{
    bool active = true;
    float FrameTime;
    float Power;
    Transform arm;
    float t = 0.0f;
    Quaternion initialRotation;
    Quaternion targetRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FrameTime = Time.deltaTime * 5;
        Power = 0;
        arm = transform.GetChild(3);
        initialRotation = arm.localRotation;
        targetRotation = initialRotation * Quaternion.AngleAxis(86, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.up * FrameTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.down * FrameTime);
        }
        /*if (keyboard.leftArrowKey.isPressed)
        {
            transform.GetChild(3).Rotate((Vector3.left * Time.deltaTime) * 100);
        }
        if (keyboard.rightArrowKey.isPressed)
        {
            transform.GetChild(3).Rotate((Vector3.right * Time.deltaTime) * 100);
        }*/

        if (Input.GetKey(KeyCode.Space) && Power < 9)
        {
            Power += 3.33f * Time.deltaTime;
        }
        if (Power > 3 && !Input.GetKey(KeyCode.Space))
        {
            t += Time.deltaTime * Power;
            arm.localRotation = Quaternion.Lerp(initialRotation, targetRotation, t);
        }

        if (Input.GetKey(KeyCode.R))
        {                                                
            Power = 0;
            t = 0.0f;

            arm.eulerAngles = new Vector3(0, 270, 0f);
        }

    }
}
