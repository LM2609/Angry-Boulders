using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class CatapultController : MonoBehaviour
{
    bool boulderfired = false;
    bool fired = false;
    bool active = true;
    float FrameTime;
    float Power;
    Transform arm;
    float t = 0.0f;
    Quaternion initialRotation;
    Quaternion targetRotation;
    public GameObject BoulderPhysical;

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

        if (Input.GetKey(KeyCode.Space) && Power < 6 && GameManager.Instance.BoulderCount >=1 && fired == false)
        {
            Power += 3.33f * Time.deltaTime;
        }

        if (Power > 2 && !Input.GetKey(KeyCode.Space) && GameManager.Instance.BoulderCount >= 1)
        {
            fired = true;
            GameManager.Instance.loaded = false;
            t += Time.deltaTime * Power;
            arm.localRotation = Quaternion.Lerp(initialRotation, targetRotation, t);
            if (arm.rotation.eulerAngles.x >= 80 && !boulderfired)
            {
                boulderfired = true;
                Instantiate(BoulderPhysical, new Vector3(14.45f, 4.6f, -25.0f), new Quaternion(0f, 0f, 0f, 0f));
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && fired == true)
        {                                                
            Power = 0;
            t = 0.0f;

            GameManager.Instance.loaded = true;
            boulderfired = false;
            fired = false;
            GameManager.Instance.BoulderCount = GameManager.Instance.BoulderCount - 1;

            arm.eulerAngles = new Vector3(0, 270, 0f);
        }

    }
}
